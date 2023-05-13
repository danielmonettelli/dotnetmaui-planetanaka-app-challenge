namespace Planetanaka;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("Kanit-Regular.ttf", "Kanit#400");
            fonts.AddFont("Kanit-Medium.ttf", "Kanit#500");
        })
        .UseMauiCommunityToolkit()
        .UseFFImageLoading();


        builder.Services.AddSingleton<IPlanetService, PlanetService>();
        builder.Services.AddTransient<PlanetViewModel>();
        builder.Services.AddTransient<PlanetsLookoutPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}