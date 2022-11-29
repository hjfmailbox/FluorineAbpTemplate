using FluorineAbpProjectName.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FluorineAbpProjectName;

[DependsOn(
    typeof(FluorineAbpProjectNameEntityFrameworkCoreTestModule)
    )]
public class FluorineAbpProjectNameDomainTestModule : AbpModule
{

}
