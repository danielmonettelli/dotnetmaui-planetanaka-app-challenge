namespace Planetanaka;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("PlanetsLookoutPage", typeof(PlanetsLookoutPage));
    }
}
