namespace Hogwart.Domain.Exceptions;

public sealed class AgeRequirementNotMetDomainException : DomainException
{
    private new const string Message = "{0} is too old or too young to study in Hogwart.";

    public AgeRequirementNotMetDomainException(string name)
        : base(
            string.Format(
                Message,
                name))
    {
    }
}
