﻿using Zeta.Movie.Shared.Common.Responses;

namespace Zeta.Movie.Application.Common.Extensions;

public static class ListExtensions
{
    public static ListResponse<T> ToListResponse<T>(this List<T> source)
    {
        return new ListResponse<T> { Items = source };
    }
}
