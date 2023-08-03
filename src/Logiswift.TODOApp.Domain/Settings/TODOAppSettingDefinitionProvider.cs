using Volo.Abp.Settings;

namespace Logiswift.TODOApp.Settings;

public class TODOAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TODOAppSettings.MySetting1));
    }
}
