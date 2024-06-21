using Zeta.Movie.Bsui.Services.AppInfo;
using Zeta.Movie.Bsui.Services.UI;

namespace Zeta.Movie.Bsui.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddBsui(this IServiceCollection services, IConfiguration configuration)
    {
        #region AppInfo
        services.AddAppInfoService(configuration);
        #endregion AppInfo

        #region User Interface
        services.AddUIService();
        #endregion User Interface

        return services;
    }
}
