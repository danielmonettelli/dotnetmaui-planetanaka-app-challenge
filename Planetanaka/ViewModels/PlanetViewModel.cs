namespace Planetanaka.ViewModels;

public partial class PlanetViewModel : BaseViewModel
{
    [ObservableProperty]
    private Border mask;

    [ObservableProperty]
    private Image imgBrand;

    [ObservableProperty]
    private Image imgBigPlanet;

    [ObservableProperty]
    private Label lblNamePlanet;

    [ObservableProperty]
    private Label lblDescriptionPlanet;

    [ObservableProperty]
    private List<Planet> planets;

    [ObservableProperty]
    private Planet selectedPlanet;


    partial void OnImgBrandChanged(Image value)
    {
        try
        {
            if (value is not null)
            {
                new Animation
                {
                     { 0, 1, new Animation(v => ImgBrand.Rotation = v, 0, 360)}
                }.Commit(ImgBrand, "ImgBrandAnimation", length: 2000, repeat: () => true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine
                ($"An error has occurred in OnImgBrandChanged():" +
                $" {ex.Message}");
        }
    }

    partial void OnSelectedPlanetChanging(Planet oldValue, Planet newValue)
    {
        try
        {
            if (oldValue is not null)
            {
                new Animation
                {
                    { 0, 1, new Animation(v =>
                      {
                        ImgBigPlanet.Rotation = v * 720;
                        ImgBigPlanet.Scale = v;
                      }, 0, 1, Easing.CubicOut)
                    },
                    { 0, 1, new Animation(v => LblNamePlanet.Opacity = v, 0, 1, Easing.SinOut) },
                    { 0, 1, new Animation(v => LblDescriptionPlanet.Opacity = v, 0, 1, Easing.SinOut) },
                }.Commit(Mask, "MixAnimations", length: 2000);
            }
            else
            {
                ImgBrand.AbortAnimation("ImgBrandAnimation");

                new Animation
                {
                    { 0, 1, new Animation(v => Mask.Opacity = v, 1, 0, Easing.SinIn) },
                }.Commit(Mask, "MaskAnimation", length: 500, finished: (d, b) =>
                {
                    Mask.IsVisible = false;
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine
                ($"An error has occurred in OnSelectedPlanetChanging(): " +
                $"{ex.Message}");
        }
    }

    private readonly IPlanetService _planetService;

    public PlanetViewModel(IPlanetService planetService)
    {
        _planetService = planetService;

        InitializePlanetsAsync();
    }

    private async Task InitializePlanetsAsync()
    {
        try
        {
            IsBusy = true;

            Planets = (List<Planet>)await _planetService.GetPlanetsAsync();

            SelectedPlanet = Planets.FirstOrDefault();
        }
        finally
        {
            IsBusy = false;
        }
    }

}
