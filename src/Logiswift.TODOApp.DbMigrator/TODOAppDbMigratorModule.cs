using Logiswift.TODOApp.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Logiswift.TODOApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TODOAppMongoDbModule),
    typeof(TODOAppApplicationContractsModule)
    )]
public class TODOAppDbMigratorModule : AbpModule
{
}
