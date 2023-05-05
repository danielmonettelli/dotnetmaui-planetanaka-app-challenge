namespace Planetanaka.Views;

public partial class WelcomePage : ContentPage
{
    private readonly WelcomeViewModel vm = new();

    public WelcomePage()
    {
        InitializeComponent();

        BindingContext = vm;

        vm.PlanetEarth = planetEarth;
    }
}