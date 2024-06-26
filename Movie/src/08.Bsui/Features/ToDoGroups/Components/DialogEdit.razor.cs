using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Zeta.Movie.Bsui.Common.Extensions;
using Zeta.Movie.Shared.Common.Responses;
using Zeta.Movie.Shared.ToDoGroups.Commands.UpdateToDoGroup;

namespace Zeta.Movie.Bsui.Features.ToDoGroups.Components;

public partial class DialogEdit
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    [Parameter]
    public UpdateToDoGroupRequest Request { get; set; } = default!;

    private bool _isLoading;
    private ErrorResponse? _error;

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnValidSubmit()
    {
        _error = null;

        _isLoading = true;

        var response = await _toDoGroupService.UpdateToDoGroupAsync(Request);

        _isLoading = false;

        if (response.Error is not null)
        {
            _error = response.Error;

            return;
        }

        MudDialog.Close(DialogResult.Ok(true));
    }

    private void OnInvalidSubmit(EditContext editContext)
    {
        _snackbar.AddErrors(editContext.GetValidationMessages());
    }
}
