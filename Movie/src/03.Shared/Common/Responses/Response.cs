﻿namespace Zeta.Movie.Shared.Common.Responses;

public abstract class Response
{
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
}
