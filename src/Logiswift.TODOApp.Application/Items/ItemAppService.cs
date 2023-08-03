using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Logiswift.TODOApp.Permissions;
using System.Linq.Expressions;
using System.Linq;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Logiswift.TODOApp.Items
{
    [Authorize(TODOAppPermissions.Items.Default)]
    public class ItemAppService : TODOAppAppService, IItemAppService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ItemManager _itemManager;
        private readonly IIdentityUserRepository _userRepository;
        public ItemAppService(
            IItemRepository itemRepository,
            ItemManager itemManager,
            IIdentityUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _itemManager = itemManager;
            _userRepository = userRepository;
        }

        public async Task<ItemDto> GetAsync(Guid id)
        {
            var item = await _itemRepository.GetAsync(id);
            return ObjectMapper.Map<Item, ItemDto>(item);
        }

        public async Task<PagedResultDto<ItemDto>> GetListAsync(GetItemListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Item.Subject);
            }

            var items = await _itemRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter,
                input.UserId
            );
           
            var totalCount = await _itemRepository.GetCountAsync(
                input.Filter,
                input.UserId);
            /*
             * 
             var totalCount = input.Filter == null
            ? await _itemRepository.CountAsync()
            : await _itemRepository.CountAsync(
                item => item.Subject.Contains(input.Filter));
             */
            var itemsDtos = ObjectMapper.Map<List<Item>, List<ItemDto>>(items);
            //Get a lookup dictionary for the related users
            var users = await GetUsersAsync(items);

            //Set UserName for the DTOs
            itemsDtos.ForEach(itemDto => itemDto.AssigneeName =
                             users[itemDto.AssigneeId].UserName);
            return new PagedResultDto<ItemDto>(
                totalCount,
                ObjectMapper.Map<List<Item>, List<ItemDto>>(items)
            );
        }
        private async Task<Dictionary<Guid, IdentityUser>>
        GetUsersAsync(List<Item> items)
        {
            var itemsIds = items.Where(items => items.UserId != Guid.Empty)
            .Select(b => b.UserId)
            .Distinct()
            .ToArray();
            var users = await _userRepository.GetListAsync();
            var _users =
                users.Where(a => itemsIds.Contains(a.Id)
            );

            return _users.ToDictionary(x => x.Id, x => x);
        }
        [Authorize(TODOAppPermissions.Items.Create)]
        public async Task<ItemDto> CreateAsync(CreateItemDto input)
        {
            var mood = await _itemManager.CreateAsync(
                input.Subject,
                input.UserId
            );

            await _itemRepository.InsertAsync(mood);

            return ObjectMapper.Map<Item, ItemDto>(mood);
        }

        [Authorize(TODOAppPermissions.Items.Edit)]
        public async Task UpdateAsync(Guid id, UpdateItemDto input)
        {
            var item = await _itemRepository.GetAsync(id);

            if (item.Subject != input.Subject)
            {
                await _itemManager.UpdateAsync(item, input.Subject);
            }

            await _itemRepository.UpdateAsync(item);
        }
        [Authorize(TODOAppPermissions.Items.Edit)]
        public async Task SetAsDoneAsync(Guid id)
        {
            var item = await _itemRepository.GetAsync(id);
            await _itemManager.SetAsDoneAsync(item);
            await _itemRepository.UpdateAsync(item);
        }
        [Authorize(TODOAppPermissions.Items.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _itemRepository.DeleteAsync(id);
        }
    }
}
