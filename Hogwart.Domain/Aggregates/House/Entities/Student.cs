namespace Hogwart.Domain.Aggregates.House.Entities;

public class Student
{
    public Student(
        string firstName, 
        string lastName,
        int age,
        bool doesSpeakParseltongue,
        bool isAmbitious,
        bool doesPlayQuidditch,
        float heightInCentimeters,
        string nationality)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        DoesSpeakParseltongue = doesSpeakParseltongue;
        IsAmbitious = isAmbitious;
        DoesPlayQuidditch = doesPlayQuidditch;
        HeightInCentimeters = heightInCentimeters;
        Nationality = nationality;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    public bool DoesSpeakParseltongue { get; }
    public bool IsAmbitious { get; }
    public bool DoesPlayQuidditch { get; }
    public float HeightInCentimeters { get; }
    public string Nationality { get; }

    public string FullName =>
        $"{FirstName} {LastName}";
}
