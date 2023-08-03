using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Logiswift.TODOApp;

[Dependency(ReplaceServices = true)]
public class TODOAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TODOApp";
}
