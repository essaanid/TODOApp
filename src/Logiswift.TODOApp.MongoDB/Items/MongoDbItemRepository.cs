using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Logiswift.TODOApp.MongoDB;
using JetBrains.Annotations;
using System.Threading;

namespace Logiswift.TODOApp.Items
{
    public class MongoDbItemRepository
        : MongoDbRepository<TODOAppMongoDbContext, Item, Guid>,
        IItemRepository
    {
        public MongoDbItemRepository(
            IMongoDbContextProvider<TODOAppMongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }
        public async Task<List<Item>> FindByUserAsync([NotNull] Guid userId)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.Where(item => item.UserId == userId).ToListAsync();
        }
        public async Task<long> GetCountAsync(
           string filter = null,
           Guid user = default,
           CancellationToken cancellationToken = default)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Item, IMongoQueryable<Item>>(
                    user != Guid.Empty,
                    n => n.UserId==user
                ).
                WhereIf<Item, IMongoQueryable<Item>>(
                    !filter.IsNullOrWhiteSpace(),
                    n => n.Subject.Contains(filter)
                )
                .As<IMongoQueryable<Item>>()
                .CountAsync();
        }

        public async Task<List<Item>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null,
            Guid user = default,
            CancellationToken cancellationToken = default
            )
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Item, IMongoQueryable<Item>>(
                    user != Guid.Empty,
                    n => n.UserId==user
                ).
                WhereIf<Item, IMongoQueryable<Item>>(
                    !filter.IsNullOrWhiteSpace(),
                    n => n.Subject.Contains(filter)
                )
                 .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(Item.CreationTime) + " DESC" : sorting)
                .As<IMongoQueryable<Item>>()
                .PageBy<Item, IMongoQueryable<Item>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));


        }
    }
}