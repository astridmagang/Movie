using Zeta.Movie.Bsui.Services.UI.MudBlazorUI;

namespace Zeta.Movie.Bsui.Services.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddUIService(this IServiceCollection services)
    {
        services.AddMudBlazorUIService();

        return services;
    }
}
