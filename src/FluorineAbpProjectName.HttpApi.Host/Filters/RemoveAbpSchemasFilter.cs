using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace FluorineAbpProjectName.Filters;

public class RemoveAbpSchemasFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var removingSchemaKeys = swaggerDoc.Components.Schemas.Keys.Where(t => t.StartsWith("Volo.Abp")).ToList();
        removingSchemaKeys.ForEach(t =>
        {
            swaggerDoc.Components.Schemas.Remove(t);
        });
    }
}