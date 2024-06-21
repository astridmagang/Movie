using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Domain.Entities;
using Zeta.Movie.Infrastructure.Persistence.Common.Constants;
using Zeta.Movie.Shared.ToDoItems.Constants;

namespace Zeta.Movie.Infrastructure.Persistence.SqlServer.Configuration;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable(nameof(IApplicationDbContext.ToDoItems), nameof(Movie));

        builder.Property(e => e.Title).HasColumnType(CommonColumnTypes.Nvarchar(MaximumLengthFor.Title));
        builder.Property(e => e.Description).HasColumnType(CommonColumnTypes.Nvarchar(MaximumLengthFor.Description));

        builder.HasOne(e => e.ToDoGroup).WithMany(e => e.ToDoItems).HasForeignKey(e => e.ToDoGroupId).OnDelete(DeleteBehavior.Restrict);
    }
}
