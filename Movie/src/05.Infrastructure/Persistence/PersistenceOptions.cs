namespace Zeta.Movie.Infrastructure.Persistence;

public class PersistenceOptions
{
    public const string SectionKey = nameof(Persistence);

    public string ConnectionString { get; set; } = default!;
}
