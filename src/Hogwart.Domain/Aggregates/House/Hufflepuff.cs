using Hogwart.Domain.Aggregates.House.Entities;

namespace Hogwart.Domain.Aggregates.House;

public sealed class Hufflepuff : House
{
    public Hufflepuff()
        : base("Hufflepuff")
    {
    }

    public override bool CanAssignStudent(Student student) =>
        true;
}
