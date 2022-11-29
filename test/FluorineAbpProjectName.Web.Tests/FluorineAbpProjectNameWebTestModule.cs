using System.Collections.Generic;
using System.Globalization;
//using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using FluorineAbpProjectName.Localization;
//using FluorineAbpProjectName.Web;
//using FluorineAbpProjectName.Web.Menus;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
//using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation.Localization;

namespace FluorineAbpProjectName;

[DependsOn(typeof(AbpAspNetCoreTestBaseModule))]
//[DependsOn(typeof(FluorineAbpProjectNameWebModule))]
[DependsOn(typeof(FluorineAbpProjectNameApplicationTestModule))]
public class FluorineAbpProjectNameWebTestModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<IMvcBuilder>(builder =>
        {
            //builder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(FluorineAbpProjectNameWebModule).Assembly));
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalizationServices(context.Services);
        ConfigureNavigationServices(context.Services);
    }

    private static void ConfigureLocalizationServices(IServiceCollection services)
    {
        var cultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("tr") };
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;
        });

        services.Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FluorineAbpProjectNameResource>()
                .AddBaseTypes(
                    typeof(AbpValidationResource)
                    //typeof(AbpUiResource)
                );
        });
    }

    private static void ConfigureNavigationServices(IServiceCollection services)
    {
        //services.Configure<AbpNavigationOptions>(options =>
        //{
        //    options.MenuContributors.Add(new FluorineAbpProjectNameMenuContributor());
        //});
    }
}
