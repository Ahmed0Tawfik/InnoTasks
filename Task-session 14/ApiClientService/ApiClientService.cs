namespace ApiClientService;

public class ApiClient : IApiClient
{
    protected readonly string _BaseUri;
    protected readonly HttpClient _httpClient;

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public ApiClient(string baseUri)
    {
        _BaseUri = baseUri ?? string.Empty;
        _httpClient = new();
        _httpClient.BaseAddress = new Uri(baseUri ?? "localhost");
    }

    public async Task<ApiResponse<string>> DeleteAsync(string url)
    {
        HttpResponseMessage? httpResponseMessage = await _httpClient.DeleteAsync(url);
        return await ToApiResponseAsync<string>(httpResponseMessage, readBody: true);
    }

    public async Task<ApiResponse<T>> GetById<T>(string url)
    {
        HttpResponseMessage? response = await _httpClient.GetAsync(url);
        return await ToApiResponseAsync<T>(response);
    }

    public async Task<ApiResponse<List<T>>> GetAllAsync<T>(string url)
    {
        HttpResponseMessage? response = await _httpClient.GetAsync(url);
        return await ToApiResponseAsync<List<T>>(response);
    }

    public async Task<ApiResponse<T>> PostAsync<T>(string url, T data)
    {
        string dataSerialized = JsonSerializer.Serialize(data);
        HttpContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");
        HttpResponseMessage? httpResponseMessage = await _httpClient.PostAsync(url, content);
        return await ToApiResponseAsync<T>(httpResponseMessage);
    }

    public async Task<ApiResponse<T>> PutAsync<T>(string url, T data)
    {
        string dataSerialized = JsonSerializer.Serialize(data, _jsonOptions);
        HttpContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");
        HttpResponseMessage? httpResponseMessage = await _httpClient.PutAsync(url, content);
        return await ToApiResponseAsync<T>(httpResponseMessage);
    }

    private static async Task<ApiResponse<T>> ToApiResponseAsync<T>(HttpResponseMessage response, bool readBody = false)
    {
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (response.IsSuccessStatusCode)
        {
            if (typeof(T) == typeof(string) && readBody)
            {
                return ApiResponse<T>.SuccessResult((T)(object)(responseContent ?? string.Empty));
            }

            if (!string.IsNullOrWhiteSpace(responseContent))
            {
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(responseContent, _jsonOptions);
                return apiResponse ?? ApiResponse<T>.ErrorResult("Failed to deserialize response");
            }
            
            return ApiResponse<T>.SuccessResult(default(T)!);
        }

        if (!string.IsNullOrWhiteSpace(responseContent))
        {
            try
            {
                var errorResponse = JsonSerializer.Deserialize<ApiResponse<T>>(responseContent, _jsonOptions);
                if (errorResponse != null)
                {
                    return errorResponse;
                }
            }
            catch
            {
            }
        }
        
        return ApiResponse<T>.ErrorResult($"Request failed with status: {response.StatusCode}");
    }
}
