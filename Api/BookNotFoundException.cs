namespace Api;
public class BookNotFoundException : DomainException
{
    public BookNotFoundException() { }
    public BookNotFoundException(string? message) : base(message) { }
    public BookNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
