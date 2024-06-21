using Zeta.Movie.Shared.Common.Responses;

namespace Zeta.Movie.Shared.ToDoItems.Commands.CreateToDoItem;

public class CreateToDoItemResponse : Response
{
    public Guid ToDoItemId { get; set; }
}
