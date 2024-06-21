using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zeta.Movie.Application.Common.Exceptions;
using Zeta.Movie.Application.Common.Mappings;
using Zeta.Movie.Application.Services.Persistence;
using Zeta.Movie.Domain.Entities;
using Zeta.Movie.Shared.ToDoGroups.Constants;
using Zeta.Movie.Shared.ToDoGroups.Queries.GetToDoGroup;

namespace Zeta.Movie.Application.ToDoGroups.Queries.GetToDoGroup;

public class GetToDoGroupQuery : IRequest<GetToDoGroupResponse>
{
    public Guid ToDoGroupId { get; set; }
}

public class GetToDoGroupResponseMapping : IMapFrom<ToDoGroup, GetToDoGroupResponse>
{
}

public class GetToDoGroupToDoItemMapping : IMapFrom<ToDoItem, GetToDoGroupToDoItem>
{
}

public class GetToDoGroupQueryHandler : IRequestHandler<GetToDoGroupQuery, GetToDoGroupResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetToDoGroupQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetToDoGroupResponse> Handle(GetToDoGroupQuery request, CancellationToken cancellationToken)
    {
        var toDoGroup = await _context.ToDoGroups
            .AsNoTracking()
            .Where(x => x.Id == request.ToDoGroupId)
            .Include(a => a.ToDoItems.OrderBy(x => x.Created))
            .SingleOrDefaultAsync(cancellationToken);

        if (toDoGroup is null)
        {
            throw new NotFoundException(DisplayTextFor.ToDoGroup, request.ToDoGroupId);
        }

        return _mapper.Map<GetToDoGroupResponse>(toDoGroup);
    }
}
