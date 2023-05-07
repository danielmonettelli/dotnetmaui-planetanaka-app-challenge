namespace Planetanaka.ViewModels;

public partial class WelcomeViewModel : BaseViewModel
{
    [ObservableProperty]
    private Image planetEarth;

    partial void OnPlanetEarthChanged(Image value)
    {
        try
        {
            if (value is not null)
            {
                new Animation
                {
                    { 0, 0.5, new Animation(v => PlanetEarth.Rotation = v, 0, 180, Easing.CubicIn) },
                    { 0.5, 1, new Animation(v => PlanetEarth.Rotation = v, 180, 360, Easing.CubicOut) }
                }.Commit(PlanetEarth, "PlanetEarthAnimation", length: 8000, repeat: () => true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine
                ($"An error has occurred in OnPlanetEarthChanged(): " +
                $"{ex.Message}");
        }
    }

    [RelayCommand]
    private async Task StartExplorationAsync()
    {
        PlanetEarth.AbortAnimation("PlanetEarthAnimation");
        await Shell.Current.GoToAsync("PlanetsLookoutPage", true);
    }
}
