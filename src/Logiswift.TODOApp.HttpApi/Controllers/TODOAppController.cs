using Logiswift.TODOApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Logiswift.TODOApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TODOAppController : AbpControllerBase
{
    protected TODOAppController()
    {
        LocalizationResource = typeof(TODOAppResource);
    }
}
