using Zeta.Movie.Bsui.Services.Logging.Serilog;

namespace Zeta.Movie.Bsui.Services.Logging;

public static class DependencyInjection
{
    public static IHostBuilder UseLoggingService(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilogLoggingService();

        return hostBuilder;
    }
}
