using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace FluorineAbpProjectName;

public class FluorineAbpProjectNameWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<FluorineAbpProjectNameWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
