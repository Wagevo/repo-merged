namespace Wagevo.Services;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class FinchAPIService : IFinchAPIService
{
    private readonly HttpClient _httpClient;
    private readonly string _accessToken;

    public FinchAPIService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _accessToken = "91d15222-eb91-42aa-8e17-a7b7e51a402d";
    }

    public async Task<string> GetEmployeesAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.tryfinch.com/employer/directory");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        request.Headers.Add("Finch-API-Version", "2020-09-17");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
}
