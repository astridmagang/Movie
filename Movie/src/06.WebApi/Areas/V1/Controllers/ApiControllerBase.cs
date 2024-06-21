using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Zeta.Movie.WebApi.Areas.V1.Controllers;

[Route("[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = default!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
