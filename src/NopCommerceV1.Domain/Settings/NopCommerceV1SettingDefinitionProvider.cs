using Volo.Abp.Settings;

namespace NopCommerceV1.Settings;

public class NopCommerceV1SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NopCommerceV1Settings.MySetting1));
    }
}
