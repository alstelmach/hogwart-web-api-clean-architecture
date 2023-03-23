namespace Hogwart.Domain.Exceptions;

public sealed class StudentMustNotBeAssignedDomainException : DomainException
{
    private new const string Message = "{0} Can't be assigned to {1}";
    
    public StudentMustNotBeAssignedDomainException(
        string studentName,
        string houseName)
            : base(
                string.Format(
                    Message,
                    studentName,
                    houseName))
    {
    }
}