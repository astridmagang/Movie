using Zeta.Movie.Application.Services.DateAndTime;

namespace Zeta.Movie.Infrastructure.DateAndTime;

public class DateAndTimeService : IDateAndTimeService
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
