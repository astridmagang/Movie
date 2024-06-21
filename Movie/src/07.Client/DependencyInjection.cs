using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zeta.Movie.Client.Services.BackEnd;

namespace Zeta.Movie.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBackEndService(configuration);

        return services;
    }
}
