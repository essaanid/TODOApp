using Volo.Abp.Modularity;

namespace Logiswift.TODOApp;

[DependsOn(
    typeof(TODOAppApplicationModule),
    typeof(TODOAppDomainTestModule)
    )]
public class TODOAppApplicationTestModule : AbpModule
{

}
