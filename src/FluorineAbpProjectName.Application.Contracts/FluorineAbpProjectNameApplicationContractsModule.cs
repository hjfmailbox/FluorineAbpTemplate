//using Volo.Abp.Account;
//using Volo.Abp.FeatureManagement;
//using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
//using Volo.Abp.PermissionManagement;
//using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FluorineAbpProjectName;

[DependsOn(typeof(FluorineAbpProjectNameDomainSharedModule))]
//[DependsOn(typeof(AbpAccountApplicationContractsModule))]
//[DependsOn(typeof(AbpFeatureManagementApplicationContractsModule))]
//[DependsOn(typeof(AbpIdentityApplicationContractsModule))]
//[DependsOn(typeof(AbpPermissionManagementApplicationContractsModule))]
//[DependsOn(typeof(AbpSettingManagementApplicationContractsModule))]
[DependsOn(typeof(AbpTenantManagementApplicationContractsModule))]
[DependsOn(typeof(AbpObjectExtendingModule))]
public class FluorineAbpProjectNameApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        FluorineAbpProjectNameDtoExtensions.Configure();
    }
}
