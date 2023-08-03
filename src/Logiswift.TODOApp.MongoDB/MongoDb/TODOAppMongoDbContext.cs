using Logiswift.TODOApp.Items;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Logiswift.TODOApp.MongoDB;

[ConnectionStringName("Default")]
public class TODOAppMongoDbContext : AbpMongoDbContext
{
 
    public IMongoCollection<Item> Items => Collection<Item>();
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.Entity<Item>(b =>
        {
            b.CollectionName = "Items";
        });
    }
}
