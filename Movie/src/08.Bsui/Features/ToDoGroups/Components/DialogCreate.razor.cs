using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Zeta.Movie.Bsui.Common.Extensions;
using Zeta.Movie.Shared.Common.Responses;
using Zeta.Movie.Shared.ToDoGroups.Commands.CreateToDoGroup;

namespace Zeta.Movie.Bsui.Features.ToDoGroups.Components;

public partial class DialogCreate
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    private CreateToDoGroupRequest _request = default!;
    private bool _isLoading;
    private ErrorResponse? _error;

    protected override void OnInitialized()
    {
        _request = new CreateToDoGroupRequest
        {
            Name = "Group 1"
        };
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnValidSubmit()
    {
        _error = null;

        _isLoading = true;

        var response = await _toDoGroupService.CreateToDoGroupAsync(_request);

        _isLoading = false;

        if (response.Error is not null)
        {
            _error = response.Error;

            return;
        }

        MudDialog.Close(DialogResult.Ok(response.Result!.ToDoGroupId));
    }

    private void OnInvalidSubmit(EditContext editContext)
    {
        _snackbar.AddErrors(editContext.GetValidationMessages());
    }
}
