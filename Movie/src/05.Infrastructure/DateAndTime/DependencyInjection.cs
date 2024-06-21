using Microsoft.Extensions.DependencyInjection;
using Zeta.Movie.Application.Services.DateAndTime;

namespace Zeta.Movie.Infrastructure.DateAndTime;

public static class DependencyInjection
{
    public static IServiceCollection AddDateAndTimeService(this IServiceCollection services)
    {
        services.AddTransient<IDateAndTimeService, DateAndTimeService>();

        return services;
    }
}
