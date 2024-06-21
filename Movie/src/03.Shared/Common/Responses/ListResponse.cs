namespace Zeta.Movie.Shared.Common.Responses;

public class ListResponse<T> : Response
{
    public IList<T> Items { get; set; } = new List<T>();
}
