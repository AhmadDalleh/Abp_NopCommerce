using Volo.Abp.Modularity;

namespace NopCommerceV1;

[DependsOn(
    typeof(NopCommerceV1ApplicationModule),
    typeof(NopCommerceV1DomainTestModule)
)]
public class NopCommerceV1ApplicationTestModule : AbpModule
{

}
