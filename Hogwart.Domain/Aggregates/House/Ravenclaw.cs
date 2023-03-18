using Hogwart.Domain.Aggregates.House.Entities;

namespace Hogwart.Domain.Aggregates.House;

public sealed class Ravenclaw : House
{
    public Ravenclaw(string name)
        : base(name)
    {
    }

    public override bool CanAssignStudent(Student student) =>
        student.DoesPlayQuidditch;
}
