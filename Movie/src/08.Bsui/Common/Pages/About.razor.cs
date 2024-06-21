using MudBlazor;
using Zeta.Movie.Bsui.Common.Constants;
using Zeta.Movie.Shared.Common.Constants;

namespace Zeta.Movie.Bsui.Common.Pages;

public partial class About
{
    private List<BreadcrumbItem> _breadcrumbItems = new();

    protected override void OnInitialized()
    {
        SetupBreadcrumb();
    }

    private void SetupBreadcrumb()
    {
        _breadcrumbItems = new()
        {
            CommonBreadcrumbFor.Home,
            CommonBreadcrumbFor.Active(CommonDisplayTextFor.About)
        };
    }
}
