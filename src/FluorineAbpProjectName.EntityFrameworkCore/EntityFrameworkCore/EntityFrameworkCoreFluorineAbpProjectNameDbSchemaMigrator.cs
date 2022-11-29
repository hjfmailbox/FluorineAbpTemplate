using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluorineAbpProjectName.Data;
using Volo.Abp.DependencyInjection;

namespace FluorineAbpProjectName.EntityFrameworkCore;

public class EntityFrameworkCoreFluorineAbpProjectNameDbSchemaMigrator
    : IFluorineAbpProjectNameDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFluorineAbpProjectNameDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the FluorineAbpProjectNameDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FluorineAbpProjectNameDbContext>()
            .Database
            .MigrateAsync();
    }
}
