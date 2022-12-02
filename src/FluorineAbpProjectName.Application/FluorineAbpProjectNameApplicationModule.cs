//using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
//using Volo.Abp.FeatureManagement;
//using Volo.Abp.Identity;
using Volo.Abp.Modularity;
#if enablePermissionManagement
using Volo.Abp.PermissionManagement;
#endif
//using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FluorineAbpProjectName;

[DependsOn(typeof(FluorineAbpProjectNameDomainModule))]
[DependsOn(typeof(FluorineAbpProjectNameApplicationContractsModule))]
//[DependsOn(typeof(AbpAccountApplicationModule))]
//[DependsOn(typeof(AbpIdentityApplicationModule))]
#if enablePermissionManagement
[DependsOn(typeof(AbpPermissionManagementApplicationModule))]
#endif
[DependsOn(typeof(AbpTenantManagementApplicationModule))]
//[DependsOn(typeof(AbpFeatureManagementApplicationModule))]
//[DependsOn(typeof(AbpSettingManagementApplicationModule))]
public class FluorineAbpProjectNameApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<FluorineAbpProjectNameApplicationModule>();
        });
    }
}
