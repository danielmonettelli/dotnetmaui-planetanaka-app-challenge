namespace Planetanaka.Views;

public partial class PlanetsLookoutPage : ContentPage
{
    public PlanetsLookoutPage(PlanetViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        vm.Mask = mask;
        vm.ImgBrand = imgBrand;
        vm.ImgBigPlanet = imgBigPlanet;
        vm.LblNamePlanet = lblNamePlanet;
        vm.LblDescriptionPlanet = lblDescriptionPlanet;
    }

}