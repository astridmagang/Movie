using Microsoft.Extensions.Hosting;
using Zeta.Movie.Infrastructure.Logging.Serilog;

namespace Zeta.Movie.Infrastructure.Logging;

public static class DependencyInjection
{
    public static IHostBuilder UseLoggingService(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilogLoggingService();

        return hostBuilder;
    }
}
