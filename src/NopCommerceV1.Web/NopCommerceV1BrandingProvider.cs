using Microsoft.Extensions.Localization;
using NopCommerceV1.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace NopCommerceV1.Web;

[Dependency(ReplaceServices = true)]
public class NopCommerceV1BrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<NopCommerceV1Resource> _localizer;

    public NopCommerceV1BrandingProvider(IStringLocalizer<NopCommerceV1Resource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
