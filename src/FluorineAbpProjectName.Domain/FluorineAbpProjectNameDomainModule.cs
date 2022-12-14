using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FluorineAbpProjectName.MultiTenancy;
#if enableAuditLogging
using Volo.Abp.AuditLogging;
#endif
#if enableBackgroundJob
using Volo.Abp.BackgroundJobs;
#endif
//using Volo.Abp.Emailing;
//using Volo.Abp.FeatureManagement;
//using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
//using Volo.Abp.OpenIddict;
#if enablePermissionManagement
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
#endif
//using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FluorineAbpProjectName;


[DependsOn(typeof(FluorineAbpProjectNameDomainSharedModule))]
#if enableAuditLogging
[DependsOn(typeof(AbpAuditLoggingDomainModule))]
#endif
#if enableBackgroundJob
[DependsOn(typeof(AbpBackgroundJobsDomainModule))]
#endif
//[DependsOn(typeof(AbpFeatureManagementDomainModule))]
//[DependsOn(typeof(AbpIdentityDomainModule))]
//[DependsOn(typeof(AbpOpenIddictDomainModule))]
#if enablePermissionManagement
[DependsOn(typeof(AbpPermissionManagementDomainOpenIddictModule))]
[DependsOn(typeof(AbpPermissionManagementDomainIdentityModule))]
#endif
//[DependsOn(typeof(AbpSettingManagementDomainModule))]
[DependsOn(typeof(AbpTenantManagementDomainModule))]
//[DependsOn(typeof(AbpEmailingModule))]
public class FluorineAbpProjectNameDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية", "ae"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("hr", "hr", "Croatian"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish", "fi"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français", "fr"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский", "ru"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak", "sk"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe", "tr"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

#if DEBUG
        //context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
