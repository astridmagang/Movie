﻿using MudBlazor;
using Zeta.Movie.Bsui.Common.Constants;
using Zeta.Movie.Shared.Common.Constants;
using Zeta.Movie.Shared.Common.Extensions;

namespace Zeta.Movie.Bsui.Common.Pages;

public partial class Index
{
    private List<BreadcrumbItem> _breadcrumbItems = new();
    private string _greetings = default!;

    protected override void OnInitialized()
    {
        SetupBreadcrumb();

        _greetings = $"Good {DateTimeOffset.Now.ToFriendlyTimeDisplayText()}";
    }

    private void SetupBreadcrumb()
    {
        _breadcrumbItems = new()
        {
            CommonBreadcrumbFor.Active(CommonDisplayTextFor.Home)
        };
    }
}
