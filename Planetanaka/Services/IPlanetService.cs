namespace Planetanaka.Services;

public interface IPlanetService
{
    Task<List<Planet>> GetPlanetsAsync();
}
