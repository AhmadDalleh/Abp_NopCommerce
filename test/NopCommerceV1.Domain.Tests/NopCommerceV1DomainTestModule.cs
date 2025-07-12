using Volo.Abp.Modularity;

namespace NopCommerceV1;

[DependsOn(
    typeof(NopCommerceV1DomainModule),
    typeof(NopCommerceV1TestBaseModule)
)]
public class NopCommerceV1DomainTestModule : AbpModule
{

}
