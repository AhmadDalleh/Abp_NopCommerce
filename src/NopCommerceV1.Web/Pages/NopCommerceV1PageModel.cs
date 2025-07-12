using NopCommerceV1.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace NopCommerceV1.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class NopCommerceV1PageModel : AbpPageModel
{
    protected NopCommerceV1PageModel()
    {
        LocalizationResourceType = typeof(NopCommerceV1Resource);
    }
}
