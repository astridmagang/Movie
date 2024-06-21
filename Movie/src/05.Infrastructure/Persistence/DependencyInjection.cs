using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Infrastructure.Persistence.Common.Constants;

namespace Zeta.Movie.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        var persistenceOptions = configuration.GetSection(PersistenceOptions.SectionKey).Get<PersistenceOptions>();

        var migrationsAssembly = typeof(ApplicationDbContext).Assembly.FullName;

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(persistenceOptions.ConnectionString, builder =>
            {
                builder.MigrationsAssembly(migrationsAssembly);
                builder.MigrationsHistoryTable(TableNameFor.EfMigrationsHistory, nameof(Movie));
                builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            options.ConfigureWarnings(wcb => wcb.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
            options.ConfigureWarnings(wcb => wcb.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
