﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Zeta.Movie.Application.Common.Models;

namespace Zeta.Movie.Application.Common.Extensions;

public static class IQueryableExtension
{
    public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return PaginatedList<T>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);
    }

    public static Task<List<T>> ProjectToListAsync<T>(this IQueryable queryable, IConfigurationProvider configuration)
    {
        return Task.Run(() => queryable.ProjectTo<T>(configuration).ToList());
    }
}
