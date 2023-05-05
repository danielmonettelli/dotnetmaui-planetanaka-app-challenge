namespace Planetanaka.Services;

public interface IPlanetService
{
    Task<IEnumerable<Planet>> GetPlanetsAsync();
}
