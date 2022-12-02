using FluorineAbpProjectName.Localization;
using Volo.Abp.Application.Services;

namespace FluorineAbpProjectName;

/* Inherit your application services from this class.
 */
public abstract class FluorineAbpProjectNameAppService : ApplicationService
{
    protected FluorineAbpProjectNameAppService()
    {
        LocalizationResource = typeof(FluorineAbpProjectNameResource);
    }
}
