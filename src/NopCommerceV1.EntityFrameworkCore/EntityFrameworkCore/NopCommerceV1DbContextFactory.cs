using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NopCommerceV1.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NopCommerceV1DbContextFactory : IDesignTimeDbContextFactory<NopCommerceV1DbContext>
{
    public NopCommerceV1DbContext CreateDbContext(string[] args)
    {
        NopCommerceV1EfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<NopCommerceV1DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new NopCommerceV1DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NopCommerceV1.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
