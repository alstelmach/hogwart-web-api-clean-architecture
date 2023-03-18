using Hogwart.Domain.Aggregates.House.Entities;

namespace Hogwart.Domain.Aggregates.House;

public sealed class Gryffindor : House
{
    public Gryffindor(string name)
        : base(name)
    {
    }

    public override bool CanAssignStudent(Student student) =>
        student.HeightInCentimeters > 180;
}
