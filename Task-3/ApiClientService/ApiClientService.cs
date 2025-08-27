
using System.Net;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public async Task<string> DeleteAsync(string url)
    {

        HttpResponseMessage? httpResponseMessage = await _httpClient.DeleteAsync(url);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }

        return "Error Deleting the Object";
    }

    public async Task<T?> GetById<T>(string url)
    {
        HttpResponseMessage? response = await _httpClient.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            T? entity = JsonSerializer.Deserialize<T>(responseContent, _jsonOptions);
            return entity;
        }
        return default;
    }

    public async Task<List<T>?>  GetAllAsync<T>(string url)
    {
        HttpResponseMessage? response = await _httpClient.GetAsync(url);

        if(response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            List<T>? entities = JsonSerializer.Deserialize<List<T>>(responseContent, _jsonOptions);
            return entities;
        }

        return default; // default of list<t> 
        
    }

    public async Task<T?> PostAsync<T>(string url, T data)
    {
        string dataSerialized = JsonSerializer.Serialize(data);
        HttpContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");

        HttpResponseMessage? httpResponseMessage = await _httpClient.PostAsync(url, content);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            return data;
        }

        return default;
    }

    public async Task<T?> PutAsync<T>(string url, T data)
    {
        string dataSerialized = JsonSerializer.Serialize(data, _jsonOptions);
        HttpContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");

        HttpResponseMessage? httpResponseMessage = await _httpClient.PutAsync(url, content);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            return data;
        }

        return default;
    }
}
