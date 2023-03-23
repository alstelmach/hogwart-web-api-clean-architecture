using Hogwart.Domain.Aggregates.House.Entities;

namespace Hogwart.Domain.Aggregates.House;

public sealed class Slytherin : House
{
    public Slytherin()
        : base("Slytherin")
    {
    }

    public override bool CanAssignStudent(Student student) =>
        student is { IsAmbitious: true, DoesSpeakParseltongue: true };
}
