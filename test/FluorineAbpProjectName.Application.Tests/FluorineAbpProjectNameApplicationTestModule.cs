using Volo.Abp.Modularity;

namespace FluorineAbpProjectName;

[DependsOn(
    typeof(FluorineAbpProjectNameApplicationModule),
    typeof(FluorineAbpProjectNameDomainTestModule)
    )]
public class FluorineAbpProjectNameApplicationTestModule : AbpModule
{

}
