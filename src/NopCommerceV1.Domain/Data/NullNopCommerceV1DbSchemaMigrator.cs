using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NopCommerceV1.Data;

/* This is used if database provider does't define
 * INopCommerceV1DbSchemaMigrator implementation.
 */
public class NullNopCommerceV1DbSchemaMigrator : INopCommerceV1DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
