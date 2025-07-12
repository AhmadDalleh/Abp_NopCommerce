using NopCommerceV1.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace NopCommerceV1.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NopCommerceV1EntityFrameworkCoreModule),
    typeof(NopCommerceV1ApplicationContractsModule)
    )]
public class NopCommerceV1DbMigratorModule : AbpModule
{
}
