using System.Threading.Tasks;

namespace FluorineAbpProjectName.Data;

public interface IFluorineAbpProjectNameDbSchemaMigrator
{
    Task MigrateAsync();
}
