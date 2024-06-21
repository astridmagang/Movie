using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zeta.Movie.Application.Common.Exceptions;
using Zeta.Movie.Application.ToDoItems.Commands.CreateToDoItem;
using Zeta.Movie.Application.ToDoItems.Commands.DeleteToDoItem;
using Zeta.Movie.Application.ToDoItems.Commands.UpdateToDoItem;
using Zeta.Movie.Application.ToDoItems.Commands.UpdateToDoItemStatus;
using Zeta.Movie.Application.ToDoItems.Queries.GetToDoItem;
using Zeta.Movie.Application.ToDoItems.Queries.GetToDoItemsByToDoGroupId;
using Zeta.Movie.Shared.Common.Requests;
using Zeta.Movie.Shared.Common.Responses;
using Zeta.Movie.Shared.ToDoItems.Commands.CreateToDoItem;
using Zeta.Movie.Shared.ToDoItems.Queries.GetToDoItem;
using Zeta.Movie.Shared.ToDoItems.Queries.GetToDoItemsByToDoGroupId;

namespace Zeta.Movie.WebApi.Areas.V1.Controllers;

public class ToDoItemsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateToDoItemResponse>> CreateToDoItem([FromForm] CreateToDoItemCommand command)
    {
        return CreatedAtAction(nameof(CreateToDoItem), await Mediator.Send(command));
    }

    [HttpPut("{toDoItemId:guid}")]
    public async Task<ActionResult> UpdateToDoItem([FromRoute] Guid toDoItemId, [FromForm] UpdateToDoItemCommand command)
    {
        if (toDoItemId != command.ToDoItemId)
        {
            throw new MismatchException(nameof(UpdateToDoItemCommand.ToDoItemId), toDoItemId, command.ToDoItemId);
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("Status/{toDoItemId:guid}")]
    public async Task<ActionResult> UpdateToDoItemStatus([FromRoute] Guid toDoItemId, [FromForm] UpdateToDoItemStatusCommand command)
    {
        if (toDoItemId != command.ToDoItemId)
        {
            throw new MismatchException(nameof(UpdateToDoItemStatusCommand.ToDoItemId), toDoItemId, command.ToDoItemId);
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{toDoItemId:guid}")]
    public async Task<ActionResult> DeleteToDoItem([FromRoute] Guid toDoItemId)
    {
        await Mediator.Send(new DeleteToDoItemCommand { ToDoItemId = toDoItemId });

        return NoContent();
    }

    [HttpGet("ByToDoGroupId/{toDoGroupId:guid}")]
    [Produces(typeof(PaginatedListResponse<GetToDoItemsByToDoGroupIdToDoItem>))]
    public async Task<ActionResult<PaginatedListResponse<GetToDoItemsByToDoGroupIdToDoItem>>> GetToDoItemsByToDoGroupId([FromRoute] Guid toDoGroupId, [FromQuery] PaginatedListRequest request)
    {
        var query = new GetToDoItemsByToDoGroupIdQuery
        {
            ToDoGroupId = toDoGroupId,
            Page = request.Page,
            PageSize = request.PageSize,
            SearchText = request.SearchText,
            SortField = request.SortField,
            SortOrder = request.SortOrder
        };

        return await Mediator.Send(query);
    }

    [HttpGet("{toDoItemId:guid}")]
    public async Task<ActionResult<GetToDoItemResponse>> GetToDoItem([FromRoute] Guid toDoItemId)
    {
        return await Mediator.Send(new GetToDoItemQuery { ToDoItemId = toDoItemId });
    }
}
