using FluentValidation;
using MediatR;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Domain.Entities;
using Zeta.Movie.Shared.ToDoGroups.Commands.CreateToDoGroup;

namespace Zeta.Movie.Application.ToDoGroups.Commands.CreateToDoGroup;

public class CreateToDoGroupCommand : CreateToDoGroupRequest, IRequest<CreateToDoGroupResponse>
{
}

public class CreateToDoGroupCommandValidator : AbstractValidator<CreateToDoGroupCommand>
{
    public CreateToDoGroupCommandValidator()
    {
        Include(new CreateToDoGroupRequestValidator());
    }
}

public class CreateToDoGroupCommandHandler : IRequestHandler<CreateToDoGroupCommand, CreateToDoGroupResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateToDoGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateToDoGroupResponse> Handle(CreateToDoGroupCommand request, CancellationToken cancellationToken)
    {
        var toDoGroup = new ToDoGroup
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _context.ToDoGroups.AddAsync(toDoGroup, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateToDoGroupResponse
        {
            ToDoGroupId = toDoGroup.Id
        };
    }
}
