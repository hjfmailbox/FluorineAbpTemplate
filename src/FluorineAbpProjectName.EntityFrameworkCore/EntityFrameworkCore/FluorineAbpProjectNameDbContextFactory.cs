using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FluorineAbpProjectName.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class FluorineAbpProjectNameDbContextFactory : IDesignTimeDbContextFactory<FluorineAbpProjectNameDbContext>
{
    public FluorineAbpProjectNameDbContext CreateDbContext(string[] args)
    {
        //<TEMPLATE-REMOVE IF-NOT='dbms:PostgreSQL'>
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        //</TEMPLATE-REMOVE>
        FluorineAbpProjectNameEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

#if sqlServer 
        var builder = new DbContextOptionsBuilder<FluorineAbpProjectNameDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new FluorineAbpProjectNameDbContext(builder.Options);
#else
        var builder = new DbContextOptionsBuilder<FluorineAbpProjectNameDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);
        return new FluorineAbpProjectNameDbContext(builder.Options);
#endif
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FluorineAbpProjectName.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
