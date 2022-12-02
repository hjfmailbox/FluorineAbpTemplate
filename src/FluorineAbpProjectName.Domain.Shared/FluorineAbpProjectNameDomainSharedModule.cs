using FluorineAbpProjectName.Localization;
#if enableAuditLogging
using Volo.Abp.AuditLogging;
#endif
#if enableBackgroundJob
using Volo.Abp.BackgroundJobs;
#endif
//using Volo.Abp.FeatureManagement;
//using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
//using Volo.Abp.OpenIddict;
//using Volo.Abp.PermissionManagement;
//using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FluorineAbpProjectName;

#if enableAuditLogging
[DependsOn(typeof(AbpAuditLoggingDomainSharedModule))]
#endif
#if enableBackgroundJob
[DependsOn(typeof(AbpBackgroundJobsDomainSharedModule))]
#endif
//[DependsOn(typeof(AbpFeatureManagementDomainSharedModule))]
//[DependsOn(typeof(AbpIdentityDomainSharedModule))]
//[DependsOn(typeof(AbpOpenIddictDomainSharedModule))]
//[DependsOn(typeof(AbpPermissionManagementDomainSharedModule))]
//[DependsOn(typeof(AbpSettingManagementDomainSharedModule))]
[DependsOn(typeof(AbpTenantManagementDomainSharedModule))]
public class FluorineAbpProjectNameDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        FluorineAbpProjectNameGlobalFeatureConfigurator.Configure();
        FluorineAbpProjectNameModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FluorineAbpProjectNameDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<FluorineAbpProjectNameResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/FluorineAbpProjectName");

            options.DefaultResourceType = typeof(FluorineAbpProjectNameResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("FluorineAbpProjectName", typeof(FluorineAbpProjectNameResource));
        });
    }
}
