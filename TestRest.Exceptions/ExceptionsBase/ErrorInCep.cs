namespace TestRest.Exceptions.ExceptionsBase;

public class ErrorInCep : TestRestException
{
    public string Message { get; set; } = string.Empty;

    public ErrorInCep(string message)
    {
        Message = message;
    }
}