namespace ApiClientService;

public interface IApiClient
{
    Task<ApiResponse<List<T>>> GetAllAsync<T>(string url);
    Task<ApiResponse<T>> GetById<T>(string url);
    Task<ApiResponse<T>> PostAsync<T>(string url, T data);
    Task<ApiResponse<T>> PutAsync<T>(string url, T data);
    Task<ApiResponse<string>> DeleteAsync(string url);
}
