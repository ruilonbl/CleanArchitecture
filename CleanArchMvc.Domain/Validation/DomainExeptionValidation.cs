namespace CleanArchMvc.Domain.Validation;

public class DomainExeptionValidation : Exception
{
    public DomainExeptionValidation(string error) : base(error) { }

    public static void When(bool hasError, string error)
    {
            if (hasError) throw new DomainExeptionValidation(error);         
    }
}