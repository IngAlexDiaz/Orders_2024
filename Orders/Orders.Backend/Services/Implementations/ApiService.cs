using Orders.Shared.Responses;
using System.Text.Json;

namespace Orders.Backend.Services.Implementations
{
    public class ApiService : IApiService
    {
        private readonly string _urlBase;
        private readonly string _tokenName;
        private readonly string _tokenValue;

        public ApiService(IConfiguration configuration)
        {
            _urlBase = configuration["CountriesBackend:urlBase"]!;
            _tokenName = configuration["CountriesBackend:tokenName"]!;
            _tokenValue = configuration["CountriesBackend:tokenValue"]!;
        }

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<ActionResponse<T>> GetAsync<T>(string servicePrefix, string controller)
        {
            try
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(_urlBase),
                };

                httpClient.DefaultRequestHeaders.Add(_tokenName, _tokenValue);
                var url = $"{servicePrefix}{controller}";
                var responseHttp = await httpClient.GetAsync(url);
                var response = await responseHttp.Content.ReadAsStringAsync();
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return new ActionResponse<T>
                    {
                        WasSuccess = false,
                        Message = response,
                    };
                }

                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = JsonSerializer.Deserialize<T>(response, _jsonDefaultOptions)!,
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
