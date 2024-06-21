using FluentValidation;
using Zeta.Movie.Base.TodoItems.Enums;
using Zeta.Movie.Shared.ToDoItems.Constants;

namespace Zeta.Movie.Shared.ToDoItems.Commands.UpdateToDoItem;

public class UpdateToDoItemRequest
{
    public Guid ToDoItemId { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public PriorityLevel PriorityLevel { get; set; }
}

public class UpdateToDoItemRequestValidator : AbstractValidator<UpdateToDoItemRequest>
{
    public UpdateToDoItemRequestValidator()
    {
        RuleFor(v => v.ToDoItemId)
            .NotEmpty();

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(MaximumLengthFor.Title);

        RuleFor(v => v.Description)
            .MaximumLength(MaximumLengthFor.Description);

        RuleFor(v => v.PriorityLevel)
            .IsInEnum();
    }
}
