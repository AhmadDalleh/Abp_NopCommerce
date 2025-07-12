using System;
using System.Collections.Generic;
using System.Text;
using NopCommerceV1.Localization;
using Volo.Abp.Application.Services;

namespace NopCommerceV1;

/* Inherit your application services from this class.
 */
public abstract class NopCommerceV1AppService : ApplicationService
{
    protected NopCommerceV1AppService()
    {
        LocalizationResource = typeof(NopCommerceV1Resource);
    }
}
