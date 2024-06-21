using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zeta.Movie.Infrastructure.AppInfo;
using Zeta.Movie.Infrastructure.DateAndTime;
using Zeta.Movie.Infrastructure.Persistence;

namespace Zeta.Movie.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppInfoService(configuration);
        services.AddDateAndTimeService();
        services.AddPersistenceService(configuration);

        return services;
    }
}
