namespace ApiClientService;

public interface IApiClient
{
    Task<List<T>?> GetAllAsync<T>(string url);
    Task<T?> GetById<T>(string url);
    Task<T?> PostAsync<T>(string url, T data);
    Task<T?> PutAsync<T>(string url, T data);
    Task<string> DeleteAsync(string url);
}
