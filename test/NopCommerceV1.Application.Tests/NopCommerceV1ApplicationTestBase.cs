using Volo.Abp.Modularity;

namespace NopCommerceV1;

public abstract class NopCommerceV1ApplicationTestBase<TStartupModule> : NopCommerceV1TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
