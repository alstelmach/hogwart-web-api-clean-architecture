using MediatR;

namespace Hogwart.Application.Contracts;

public sealed record AssignStudentToHouseCommand(
    string FirstName,
    string LastName,
    string Nationality,
    int Age,
    float HeightInCentimeters,
    bool DoesSpeakParseltongue,
    bool DoesPlayQuidditch,
    bool IsAmbitious) : IRequest;
