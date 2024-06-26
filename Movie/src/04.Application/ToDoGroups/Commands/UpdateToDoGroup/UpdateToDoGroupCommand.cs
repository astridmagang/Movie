﻿using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zeta.Movie.Application.Common.Exceptions;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Shared.ToDoGroups.Commands.UpdateToDoGroup;
using Zeta.Movie.Shared.ToDoGroups.Constants;

namespace Zeta.Movie.Application.ToDoGroups.Commands.UpdateToDoGroup;

public class UpdateToDoGroupCommand : UpdateToDoGroupRequest, IRequest
{
}

public class UpdateToDoGroupCommandValidator : AbstractValidator<UpdateToDoGroupCommand>
{
    public UpdateToDoGroupCommandValidator()
    {
        Include(new UpdateToDoGroupRequestValidator());
    }
}

public class UpdateToDoGroupCommandHandler : IRequestHandler<UpdateToDoGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateToDoGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateToDoGroupCommand request, CancellationToken cancellationToken)
    {
        var toDoGroup = await _context.ToDoGroups
            .Where(x => x.Id == request.ToDoGroupId)
            .SingleOrDefaultAsync(cancellationToken);

        if (toDoGroup is null)
        {
            throw new NotFoundException(DisplayTextFor.ToDoGroup, request.ToDoGroupId);
        }

        toDoGroup.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
