using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Domain.Entities;
using Zeta.Movie.Infrastructure.Persistence.Common.Constants;
using Zeta.Movie.Shared.ToDoGroups.Constants;

namespace Zeta.Movie.Infrastructure.Persistence.SqlServer.Configuration;

public class ToDoGroupConfiguration : IEntityTypeConfiguration<ToDoGroup>
{
    public void Configure(EntityTypeBuilder<ToDoGroup> builder)
    {
        builder.ToTable(nameof(IApplicationDbContext.ToDoGroups), nameof(Movie));

        builder.Property(e => e.Name).HasColumnType(CommonColumnTypes.Nvarchar(MaximumLengthFor.Name));
    }
}
