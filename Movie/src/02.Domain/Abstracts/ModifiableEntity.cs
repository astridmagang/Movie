using Zeta.Movie.Domain.Interfaces;

namespace Zeta.Movie.Domain.Abstracts;

public abstract class ModifiableEntity : Entity, IModifiable
{
    public DateTimeOffset? Modified { get; set; }
}
