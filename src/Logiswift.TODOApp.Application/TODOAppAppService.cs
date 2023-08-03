using System;
using System.Collections.Generic;
using System.Text;
using Logiswift.TODOApp.Localization;
using Volo.Abp.Application.Services;

namespace Logiswift.TODOApp;

/* Inherit your application services from this class.
 */
public abstract class TODOAppAppService : ApplicationService
{
    protected TODOAppAppService()
    {
        LocalizationResource = typeof(TODOAppResource);
    }
}
