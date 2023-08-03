using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Logiswift.TODOApp.Items
{

    public interface IItemRepository : IRepository<Item, Guid>
    {
        Task<List<Item>> FindByUserAsync(Guid userId);

        Task<List<Item>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null,
            Guid user = default,
            CancellationToken cancellationToken = default
        );
        Task<long> GetCountAsync(
            string filter = null,
            Guid user = default,
            CancellationToken cancellationToken = default
        );
    }
}
