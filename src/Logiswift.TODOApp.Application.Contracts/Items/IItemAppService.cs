using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Logiswift.TODOApp.Items
{
    public interface IItemAppService : IApplicationService
    {
        Task<ItemDto> GetAsync(Guid id);

        Task<PagedResultDto<ItemDto>> GetListAsync(GetItemListDto input);

        Task<ItemDto> CreateAsync(CreateItemDto input);

        Task UpdateAsync(Guid id, UpdateItemDto input);

        Task DeleteAsync(Guid id);
    }
}
