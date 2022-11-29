using FluorineAbpProjectName.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
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

[DependsOn(typeof(AbpAuditLoggingDomainSharedModule))]
[DependsOn(typeof(AbpBackgroundJobsDomainSharedModule))]
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
