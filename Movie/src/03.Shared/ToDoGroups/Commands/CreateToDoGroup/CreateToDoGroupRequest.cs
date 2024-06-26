﻿using FluentValidation;
using Zeta.Movie.Shared.ToDoGroups.Constants;

namespace Zeta.Movie.Shared.ToDoGroups.Commands.CreateToDoGroup;

public class CreateToDoGroupRequest
{
    public string Name { get; set; } = default!;
}

public class CreateToDoGroupRequestValidator : AbstractValidator<CreateToDoGroupRequest>
{
    public CreateToDoGroupRequestValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(MaximumLengthFor.Name);
    }
}
