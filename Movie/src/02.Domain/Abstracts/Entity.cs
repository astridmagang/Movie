using Zeta.Movie.Domain.Interfaces;

namespace Zeta.Movie.Domain.Abstracts;

public abstract class Entity : ICreatable
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; set; }
}
