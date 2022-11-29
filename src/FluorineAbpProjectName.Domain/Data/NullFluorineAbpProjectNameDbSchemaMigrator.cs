using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FluorineAbpProjectName.Data;

/* This is used if database provider does't define
 * IFluorineAbpProjectNameDbSchemaMigrator implementation.
 */
public class NullFluorineAbpProjectNameDbSchemaMigrator : IFluorineAbpProjectNameDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
