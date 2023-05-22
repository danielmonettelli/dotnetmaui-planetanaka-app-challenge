namespace Planetanaka.Services;

public class PlanetService : IPlanetService
{
    private readonly HttpClient _httpClient;

    public PlanetService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Planet>> GetPlanetsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Planet>>(APIConstants.APIMochaUrl);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("HTTP request error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Overall error: " + ex.Message);
        }

        return null;
    }

}
