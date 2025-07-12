using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NopCommerceV1.Data;
using Volo.Abp.DependencyInjection;

namespace NopCommerceV1.EntityFrameworkCore;

public class EntityFrameworkCoreNopCommerceV1DbSchemaMigrator
    : INopCommerceV1DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNopCommerceV1DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the NopCommerceV1DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NopCommerceV1DbContext>()
            .Database
            .MigrateAsync();
    }
}
