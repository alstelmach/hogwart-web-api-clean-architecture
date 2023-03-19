using Hogwart.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hogwart.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HousesController : ControllerBase
{
    private readonly IMediator _mediator;

    public HousesController(IMediator mediator) =>
        _mediator = mediator;

    [HttpGet("{houseName}")]
    public async Task<IActionResult> GetAsync(
        [FromRoute] string houseName,
        CancellationToken cancellationToken = default)
    {
        var query = new GetHouseQuery(houseName);
        var house = await _mediator.Send(query, cancellationToken);

        return house is null
            ? NotFound()
            : Ok(house);
    }
}