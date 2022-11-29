using FluorineAbpProjectName.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FluorineAbpProjectName.DbMigrator;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(FluorineAbpProjectNameEntityFrameworkCoreModule))]
[DependsOn(typeof(FluorineAbpProjectNameApplicationContractsModule))]
public class FluorineAbpProjectNameDbMigratorModule : AbpModule
{

}
