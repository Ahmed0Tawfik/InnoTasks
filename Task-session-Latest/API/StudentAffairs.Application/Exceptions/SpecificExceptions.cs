namespace StudentAffairs.Application;
public class NotFoundException : AppException
{
    public NotFoundException(string message)
        : base(message, ErrorStatusCodes.NotFound) { }
}

public class ValidationException : AppException
{
    public ValidationException(string message)
        : base(message, ErrorStatusCodes.BadRequest) { }
}

public class ConflictException : AppException
{
    public ConflictException(string message)
        : base(message, ErrorStatusCodes.Conflict) { }
}