using MudBlazor;
using Zeta.Movie.Bsui.Common.Constants;
using Zeta.Movie.Bsui.Common.Extensions;
using Zeta.Movie.Bsui.Features.ToDoGroups.Components;
using Zeta.Movie.Bsui.Features.ToDoGroups.Constants;
using Zeta.Movie.Shared.Common.Constants;
using Zeta.Movie.Shared.Common.Responses;
using Zeta.Movie.Shared.ToDoGroups.Constants;
using Zeta.Movie.Shared.ToDoGroups.Queries.GetToDoGroups;

namespace Zeta.Movie.Bsui.Features.ToDoGroups;

public partial class Index
{
    private ErrorResponse? _error;
    private List<BreadcrumbItem> _breadcrumbItems = new();
    private MudTable<GetToDoGroupsToDoGroup> _tableToDoGroups = new();
    private string? _searchKeyword;

    protected override void OnInitialized()
    {
        SetupBreadcrumb();
    }

    private void SetupBreadcrumb()
    {
        _breadcrumbItems = new()
        {
            CommonBreadcrumbFor.Home,
            CommonBreadcrumbFor.Active(DisplayTextFor.ToDoGroups)
        };
    }

    private async Task<TableData<GetToDoGroupsToDoGroup>> ReloadTableToDoGroups(TableState state)
    {
        _error = null;

        StateHasChanged();

        var tableData = new TableData<GetToDoGroupsToDoGroup>();
        var request = state.ToPaginatedListRequest(_searchKeyword);
        var response = await _toDoGroupService.GetToDoGroupsAsync(request);

        _error = response.Error;

        StateHasChanged();

        if (response.Result is null)
        {
            return tableData;
        }

        return response.Result.ToTableData();
    }

    private async Task OnSearch(string keyword)
    {
        _searchKeyword = keyword.Trim();

        await _tableToDoGroups.ReloadServerData();
    }

    private async Task ShowDialogCreate()
    {
        var dialog = _dialogService.Show<DialogCreate>($"{CommonDisplayTextFor.Create} {DisplayTextFor.ToDoGroup}");
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            var id = (Guid)result.Data;

            _snackbar.AddSuccess(SuccessMessageFor.Action(DisplayTextFor.ToDoGroup, CommonDisplayTextFor.Created));
            _navigationManager.NavigateTo(RouteFor.Details(id));
        }
    }
}
