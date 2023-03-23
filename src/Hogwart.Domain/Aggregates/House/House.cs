using Hogwart.Domain.Aggregates.House.Entities;
using Hogwart.Domain.Exceptions;

namespace Hogwart.Domain.Aggregates.House;

public abstract class House
{
    private readonly List<Student> _students = new();

    public House(string name) =>
        Name = name;

    public string Name { get; }

    public IReadOnlyList<Student> Students =>
        _students.AsReadOnly();

    public abstract bool CanAssignStudent(Student student);

    public void AssignStudent(Student student)
    {
        if (student is { Age: > 18 or < 11 })
        {
            throw new AgeRequirementNotMetDomainException(student.FullName);
        }

        var canAssignStudent = CanAssignStudent(student);

        if (!canAssignStudent)
        {
            throw new StudentMustNotBeAssignedDomainException(student.FullName, Name);
        }

        _students.Add(student);
    }
}
