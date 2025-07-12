using Volo.Abp.Modularity;

namespace NopCommerceV1;

/* Inherit from this class for your domain layer tests. */
public abstract class NopCommerceV1DomainTestBase<TStartupModule> : NopCommerceV1TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
