namespace StudentAffairs.Application;

public abstract class AppException : Exception
{
    public ErrorStatusCodes StatusCode { get; }

    protected AppException(string message, ErrorStatusCodes statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
