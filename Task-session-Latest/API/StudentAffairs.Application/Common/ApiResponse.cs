namespace StudentAffairs.Application.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public static ApiResponse<T> SuccessResult(T data)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Error = null
        };
    }

    public static ApiResponse<T> ErrorResult(string error)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Data = default,
            Error = error
        };
    }
}

public class ApiResponse : ApiResponse<object>
{
    public static ApiResponse SuccessResult()
    {
        return new ApiResponse
        {
            Success = true,
            Data = null,
            Error = null
        };
    }

    public static ApiResponse ErrorResult(string error)
    {
        return new ApiResponse
        {
            Success = false,
            Data = null,
            Error = error
        };
    }
}
