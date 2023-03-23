using Hogwart.Domain.Aggregates.House.Entities;

namespace Hogwart.Domain.Aggregates.House;

public sealed class Ravenclaw : House
{
    public Ravenclaw()
        : base("Ravenclaw")
    {
    }

    public override bool CanAssignStudent(Student student) =>
        student.DoesPlayQuidditch;
}
