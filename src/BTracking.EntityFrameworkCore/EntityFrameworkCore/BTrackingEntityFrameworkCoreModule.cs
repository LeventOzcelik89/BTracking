using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Azure;
using Microsoft.VisualBasic;
using NetTopologySuite.Geometries;
using System.Data;
using BTracking.UT.Countries;
using BTracking.UT.Cities;
using BTracking.FNC.FinanceDailyData;

namespace BTracking.EntityFrameworkCore;

[DependsOn(
    typeof(BTrackingDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class BTrackingEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        BTrackingEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        context.Services.AddAbpDbContext<BTrackingDbContext>(options =>
        {

            options.AddDefaultRepositories(includeAllEntities: true);

            options.AddRepository<Country, EfCoreCountryRepository>();
            options.AddRepository<City, EfCoreCityRepository>();
            options.AddRepository<Country, EfCoreCountryRepository>();
            options.AddRepository<FinanceDailyData, EfCoreFinanceDailyDataRepository>();

        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also BTrackingMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer(sqlOption => sqlOption.UseNetTopologySuite());
        });

    }
}
