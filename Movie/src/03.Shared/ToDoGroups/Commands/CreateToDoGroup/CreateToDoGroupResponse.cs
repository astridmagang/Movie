using Zeta.Movie.Shared.Common.Responses;

namespace Zeta.Movie.Shared.ToDoGroups.Commands.CreateToDoGroup;

public class CreateToDoGroupResponse : Response
{
    public Guid ToDoGroupId { get; set; }
}
