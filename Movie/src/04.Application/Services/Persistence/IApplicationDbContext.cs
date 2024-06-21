using Microsoft.EntityFrameworkCore;
using Zeta.Movie.Domain.Entities;

namespace Zeta.Movie.Application.Services.Persistence;

public interface IApplicationDbContext
{
    DbSet<ToDoGroup> ToDoGroups { get; }
    DbSet<ToDoItem> ToDoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
