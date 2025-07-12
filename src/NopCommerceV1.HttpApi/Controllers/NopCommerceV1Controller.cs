using NopCommerceV1.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NopCommerceV1.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NopCommerceV1Controller : AbpControllerBase
{
    protected NopCommerceV1Controller()
    {
        LocalizationResource = typeof(NopCommerceV1Resource);
    }
}
