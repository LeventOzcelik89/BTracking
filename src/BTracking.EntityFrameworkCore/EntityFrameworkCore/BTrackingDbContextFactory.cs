using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BTracking.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BTrackingDbContextFactory : IDesignTimeDbContextFactory<BTrackingDbContext>
{
    public BTrackingDbContext CreateDbContext(string[] args)
    {
        BTrackingEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BTrackingDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"), sqlOption => sqlOption.UseNetTopologySuite());

        return new BTrackingDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BTracking.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
