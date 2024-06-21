namespace Zeta.Movie.Domain.Interfaces;

public interface IModifiable
{
    DateTimeOffset? Modified { get; set; }
}
