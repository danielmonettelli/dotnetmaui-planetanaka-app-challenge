namespace Planetanaka.Services;

public class PlanetService : IPlanetService
{
    private readonly HttpClient _httpClient;

    public PlanetService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IEnumerable<Planet>> GetPlanetsAsync()
    {
        try
        {
            return await _httpClient
                .GetFromJsonAsync<IEnumerable<Planet>>(APIConstants.APIMochaUrl);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API request failed: {ex.Message}");
            return Enumerable.Empty<Planet>();
        }
    }

}
