namespace ApiClientService;

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