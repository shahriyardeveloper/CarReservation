using FluentValidation.Results;

namespace CarReservation.Application.Exception;

public class ValidationException : System.Exception
{
    public ValidationException() : base()
    {
        Errors = new();
    }

    public List<string> Errors { get; set; }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (ValidationFailure failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}

