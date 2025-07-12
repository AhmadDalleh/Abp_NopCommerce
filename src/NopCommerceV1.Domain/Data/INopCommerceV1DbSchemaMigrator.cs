using System.Threading.Tasks;

namespace NopCommerceV1.Data;

public interface INopCommerceV1DbSchemaMigrator
{
    Task MigrateAsync();
}
