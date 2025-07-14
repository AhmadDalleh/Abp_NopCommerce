using Microsoft.EntityFrameworkCore;
using NopCommerceV1.Customers;
using NopCommerceV1.GenericAttributes;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace NopCommerceV1.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class NopCommerceV1DbContext :
    AbpDbContext<NopCommerceV1DbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
   


    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    public DbSet<CustomerRole> CustomerRoles { get; set; }

    public DbSet<GenericAttribute> GenericAttributes { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<RewardPointsHistory> RewardPointsHistories { get; set; }

    public DbSet<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }


    #endregion

    public NopCommerceV1DbContext(DbContextOptions<NopCommerceV1DbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        #region Table Configuratins  
        /* Configure your own tables/entities inside here */

        //Customer Role Configuration
        builder.Entity<CustomerRole>(b =>
        {
            b.ToTable("CustomerRoles");
            b.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

            b.Property(x => x.FreeShipping)
            .IsRequired();

            b.Property(x=>x.TaxExempt)
            .IsRequired();

            b.Property(x => x.SystemName)
            .HasMaxLength(255);

            b.Property(x=>x.Active)
            .IsRequired();

            b.HasIndex(x => x.Name).IsUnique();
            b.HasIndex(x => x.SystemName).IsUnique();
        });


        //Customer Password Configuration
        builder.Entity<CustomerPassword>(b =>
        {
            b.ToTable("CustomerPasswords");

            b.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(512);

            b.Property(x => x.PasswordFormatId)
            .IsRequired();

            b.Property(x => x.CreatedOnUtc)
            .IsRequired();

            b.HasOne(x => x.Customer)
            .WithMany(x => x.CustomerPasswords)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        //Customer Configuration
        builder.Entity<Customer>(b =>
        {
            b.ToTable("Customers");

            b.Property(x => x.Username)
            .HasMaxLength(100)
            .IsRequired();

            b.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

            b.Property(x => x.PhoneNumber)
            .HasMaxLength(50);

            b.Property(x => x.Active)
            .IsRequired();

            b.Property(x => x.Deleted)
            .IsRequired();

            b.HasIndex(x => x.Email).IsUnique();
            b.HasIndex(x => x.Username).IsUnique();

            b.HasMany(x => x.CustomerRoles)
                .WithMany(x => x.Customers)
                .UsingEntity(j => j.ToTable("Customer_CustomerRole_Mapping"));

            b.HasMany(x => x.CustomerPasswords)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

            // M:N with Address table (CustomerAddresses)
            b.HasMany(x => x.Addresses)
            .WithMany()
            .UsingEntity(j => j.ToTable("CustomerAddresses"));

            //One-to-One: Billing and Shipping Address
            b.HasOne(x => x.BillingAddress)
            .WithMany()
            .HasForeignKey(x => x.BillingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.ShippingAddress)
           .WithMany()
           .HasForeignKey(x => x.ShippingAddressId)
           .OnDelete(DeleteBehavior.Restrict);
        });

        //Generic Attribute Configuration
        builder.Entity<GenericAttribute>(b =>
        {
            b.ToTable("GenericAttribute");

            b.Property(x => x.EntityId)
            .IsRequired();

            b.Property(x => x.KeyGroup)
            .IsRequired()
            .HasMaxLength(400);

            b.Property(x => x.key)
            .IsRequired()
            .HasMaxLength(400);

            b.Property(x => x.Value)
            .HasMaxLength(4000);

            b.HasIndex(x => new { x.EntityId, x.KeyGroup, x.key });
        });

        //Address Configuration
        builder.Entity<Address>(b =>
        {
            b.ToTable("Address");

            b.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            b.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            b.Property(x => x.Email).HasMaxLength(100).IsRequired();
            b.Property(x => x.Company).HasMaxLength(100);
            b.Property(x => x.CountryId).HasMaxLength(50);
            b.Property(x => x.City).HasMaxLength(100);
            b.Property(x => x.Address1).HasMaxLength(100);
            b.Property(x => x.Address2).HasMaxLength(100);
            b.Property(x => x.ZipPostalCode).HasMaxLength(100);
            b.Property(x => x.PhoneNumber).HasMaxLength(100);
            b.Property(x => x.FaxNumber).HasMaxLength(100);

        });

        //RewardPointsHistory Configuration
        builder.Entity<RewardPointsHistory>(b =>
        {
            b.ToTable("RewardPointsHistory");

            b.Property(x => x.CustomerId).IsRequired();
            b.Property(x => x.Points).IsRequired();
            b.Property(x => x.Message).HasMaxLength(1000).IsRequired();
            b.Property(x => x.CreatedOnUtc).IsRequired();
            b.Property(x => x.EndDateOnUtc);
            b.Property(x => x.UseWithOrderId);
            b.Property(x => x.StoreId);

            b.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)   
            .OnDelete(DeleteBehavior.Cascade);

            b.HasIndex(x => x.CustomerId);
        });

        //NewsLetterSubscription Configuration
        builder.Entity<NewsLetterSubscription>(b =>
        {
            b.ToTable("NewsLetterSubscription");

            b.Property(x => x.Email)
            .IsRequired().HasMaxLength(255);

            b.Property(x => x.Active).IsRequired();
            b.Property(x => x.CreatedOnUtc).IsRequired();

            b.Property(x => x.StoreId);

            b.HasIndex(x => new { x.Email, x.StoreId }).IsUnique();

            b.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
        });
        #endregion
    }
}
