using MediatR;

namespace Hogwart.Application.Contracts;

public record MoveStudentToOtherHouseCommand(
    int StudentId,
    string DestinationHouseName) : IRequest;
