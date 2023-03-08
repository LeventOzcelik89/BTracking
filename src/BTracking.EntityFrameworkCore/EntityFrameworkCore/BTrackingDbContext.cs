using BTracking.UT.Cities;
using BTracking.UT.Countries;
using BTracking.UT.Towns;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace BTracking.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BTrackingDbContext :
    AbpDbContext<BTrackingDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Town> Towns { get; set; }

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

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public BTrackingDbContext(DbContextOptions<BTrackingDbContext> options)
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

        /* Configure your own tables/entities inside here */

        builder.Entity<Country>(b =>
        {
            b.ToTable(BTrackingConsts.DbTablePrefix + "Country", BTrackingConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(a => a.Id).HasDefaultValueSql("(NEWSEQUENTIALID())");
            b.Property(a => a.CreationTime).HasDefaultValueSql("(GETDATE())");
            b.Property(a => a.Shape).HasColumnName(nameof(Country.Shape)).HasColumnType("geometry");
            b.Property(a => a.Code).HasColumnName(nameof(Country.Code)).HasMaxLength(CountryConsts.PropertyCodeMaxLength).IsRequired();
            b.Property(a => a.Name).HasColumnName(nameof(Country.Name)).HasMaxLength(CountryConsts.PropertyNameMaxLength).IsRequired();
        });

        builder.Entity<City>(b =>
        {
            b.ToTable(BTrackingConsts.DbTablePrefix + "City", BTrackingConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(a => a.Id).HasDefaultValueSql("(NEWSEQUENTIALID())");
            b.Property(a => a.CreationTime).HasDefaultValueSql("(GETDATE())");
            b.Property(a => a.Shape).HasColumnName(nameof(Country.Shape)).HasColumnType("geometry");
            b.Property(a => a.Name).HasColumnName(nameof(Country.Name)).HasMaxLength(CityConsts.PropertyNameMaxLength).IsRequired();
            b.HasMany(a => a.CityTowns).WithOne(a => a.TownCity).HasForeignKey(a => a.CityId);
        });

        builder.Entity<Town>(b =>
        {
            b.ToTable(BTrackingConsts.DbTablePrefix + "Town", BTrackingConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(a => a.Id).HasDefaultValueSql("(NEWSEQUENTIALID())");
            b.Property(a => a.CreationTime).HasDefaultValueSql("(GETDATE())");
            b.Property(a => a.Shape).HasColumnName(nameof(Country.Shape)).HasColumnType("geometry");
            b.Property(a => a.Name).HasColumnName(nameof(Country.Name)).HasMaxLength(TownConsts.PropertyNameMaxLength).IsRequired();
        });

    }
}
