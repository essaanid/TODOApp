using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Logiswift.TODOApp.Items
{
    public class ItemManager : DomainService
    {
        private readonly IItemRepository _itemRepository;

        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateAsync(
            [NotNull] string subject,
            [NotNull] Guid userId)
        {
            Check.NotNullOrWhiteSpace(subject, nameof(subject));

            return new Item(
                GuidGenerator.Create(),
                subject,
                userId
            );
        }

        public async Task UpdateAsync(
            [NotNull] Item item,
            [NotNull] string newSubject)
        {
            Check.NotNull(item, nameof(item));
            Check.NotNullOrWhiteSpace(newSubject, nameof(newSubject));


            item.ChangeSubject(newSubject);
        }
        public async Task SetAsDoneAsync(
           [NotNull] Item item)
        {
            Check.NotNull(item, nameof(item));
            item.SetAsDone();
        }
    }
}
