using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
#if enableAuditLogging
using Volo.Abp.AuditLogging.EntityFrameworkCore;
#endif
#if enableBackgroundJob
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
#endif
using Volo.Abp.EntityFrameworkCore;
//using Volo.Abp.EntityFrameworkCore.SqlServer;
//using Volo.Abp.FeatureManagement.EntityFrameworkCore;
//using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
//using Volo.Abp.OpenIddict.EntityFrameworkCore;
//using Volo.Abp.PermissionManagement.EntityFrameworkCore;
//using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace FluorineAbpProjectName.EntityFrameworkCore;

[DependsOn(typeof(FluorineAbpProjectNameDomainModule))]
//[DependsOn(typeof(AbpIdentityEntityFrameworkCoreModule))]
//[DependsOn(typeof(AbpOpenIddictEntityFrameworkCoreModule))]
//[DependsOn(typeof(AbpPermissionManagementEntityFrameworkCoreModule))]
//[DependsOn(typeof(AbpSettingManagementEntityFrameworkCoreModule))]
//[DependsOn(typeof(AbpEntityFrameworkCoreSqlServerModule))]
#if enableBackgroundJob
[DependsOn(typeof(AbpBackgroundJobsEntityFrameworkCoreModule))]
#endif
#if enableAuditLogging
[DependsOn(typeof(AbpAuditLoggingEntityFrameworkCoreModule))]
#endif
[DependsOn(typeof(AbpTenantManagementEntityFrameworkCoreModule))]
//[DependsOn(typeof(AbpFeatureManagementEntityFrameworkCoreModule)
public class FluorineAbpProjectNameEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        //<TEMPLATE-REMOVE IF-NOT='dbms:PostgreSQL'>
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        //</TEMPLATE-REMOVE>
        FluorineAbpProjectNameEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<FluorineAbpProjectNameDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also FluorineAbpProjectNameMigrationsDbContextFactory for EF Core tooling. */
#if mySQL
            options.UseMySQL();
#endif
#if sqlServer
            options.UseSqlServer();  
#endif

        });

        //<TEMPLATE-REMOVE IF-NOT='dbms:SQLite'>
        Configure<AbpUnitOfWorkDefaultOptions>(options =>
        {
            options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
        });
        //</TEMPLATE-REMOVE>
    }
}
