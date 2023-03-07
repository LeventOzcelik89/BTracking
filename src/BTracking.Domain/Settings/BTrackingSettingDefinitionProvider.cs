using Volo.Abp.Settings;

namespace BTracking.Settings;

public class BTrackingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BTrackingSettings.MySetting1));
    }
}
