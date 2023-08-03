using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Logiswift.TODOApp.MongoDB;

[DependsOn(
    typeof(TODOAppTestBaseModule),
    typeof(TODOAppMongoDbModule)
    )]
public class TODOAppMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = TODOAppMongoDbFixture.GetRandomConnectionString();
        });
    }
}
