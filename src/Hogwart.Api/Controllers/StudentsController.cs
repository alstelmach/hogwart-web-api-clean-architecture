using Hogwart.Api.Requests;
using Hogwart.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hogwart.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator) =>
        _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> PostAsync(
        [FromBody] AssignStudentToHouseCommand command,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            command,
            cancellationToken);

        // This is a little violation, we've taken because we want to keep the whole reference material simple.
        // In real life we should have returned 201 instead of 204 I think.
        return NoContent();
    }

    [HttpPatch("{studentId:int}")]
    public async Task<IActionResult> PatchAsync(
        [FromRoute] int studentId,
        [FromBody] PatchStudentHouseRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new MoveStudentToOtherHouseCommand(
            studentId,
            request.House);

        await _mediator.Send(
            command,
            cancellationToken);

        return NoContent();
    }
}
