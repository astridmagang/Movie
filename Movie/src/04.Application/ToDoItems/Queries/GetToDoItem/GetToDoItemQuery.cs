﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zeta.Movie.Application.Common.Exceptions;
using Zeta.Movie.Application.Common.Mappings;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Domain.Entities;
using Zeta.Movie.Shared.ToDoItems.Constants;
using Zeta.Movie.Shared.ToDoItems.Queries.GetToDoItem;

namespace Zeta.Movie.Application.ToDoItems.Queries.GetToDoItem;

public class GetToDoItemQuery : IRequest<GetToDoItemResponse>
{
    public Guid ToDoItemId { get; set; }
}

public class GetToDoItemResponseMapping : IMapFrom<ToDoItem, GetToDoItemResponse>
{
}

public class GetToDoItemQueryHandler : IRequestHandler<GetToDoItemQuery, GetToDoItemResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetToDoItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetToDoItemResponse> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
    {
        var toDoItem = await _context.ToDoItems
            .AsNoTracking()
            .Where(x => x.Id == request.ToDoItemId)
            .SingleOrDefaultAsync(cancellationToken);

        if (toDoItem is null)
        {
            throw new NotFoundException(DisplayTextFor.ToDoItem, request.ToDoItemId);
        }

        return _mapper.Map<GetToDoItemResponse>(toDoItem);
    }
}
