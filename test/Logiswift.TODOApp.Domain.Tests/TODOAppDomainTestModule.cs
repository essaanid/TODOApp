using Logiswift.TODOApp.MongoDB;
using Volo.Abp.Modularity;

namespace Logiswift.TODOApp;

[DependsOn(
    typeof(TODOAppMongoDbTestModule)
    )]
public class TODOAppDomainTestModule : AbpModule
{

}
