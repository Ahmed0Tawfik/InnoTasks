namespace StudentAffairs.API;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    //private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next /*ILogger<ExceptionMiddleware> logger*/)
    {
        _next = next;
        //_logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode statusCode;
        string message;

        if (ex is AppException exception)
        {
            statusCode = (HttpStatusCode)exception.StatusCode;
            message = ex.Message;
        }
        else
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = "An unexpected error occurred.";
        }

        context.Response.StatusCode = (int)statusCode;

        var response = ApiResponse.ErrorResult(message);
        var result = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(result);
    }
}
