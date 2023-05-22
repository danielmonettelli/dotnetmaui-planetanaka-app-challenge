namespace Planetanaka.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    public BaseViewModel() =>
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

    ~BaseViewModel() =>
        Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;

    private static async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        TimeSpan unlimitedDuration = TimeSpan.MaxValue;
        const string constrainedInternet = "Internet access is available but is limited.";
        const string lostInternet = "Without connection";
        const string activeWifi = "Online again on Wifi";
        const string activeEthernet = "Online again om Ethernet";
        const string activeCell = "Online again on Cell";
        const string activeBluetooth = "Online again on Bluetooth";

        SnackbarOptions snackbarWithoutInternet = new()
        {
            BackgroundColor = Color.FromRgba("#212121"),
            TextColor = Colors.White,
        };

        SnackbarOptions snackbarWithInternet = new()
        {
            BackgroundColor = Color.FromRgba("#2CA641"),
            TextColor = Colors.White
        };

        if (e.NetworkAccess == NetworkAccess.ConstrainedInternet)
            await Snackbar.Make(constrainedInternet).Show();

        else if (e.NetworkAccess != NetworkAccess.Internet)
            await Snackbar.Make
                (lostInternet,
                actionButtonText: string.Empty,
                duration: unlimitedDuration,
                visualOptions: snackbarWithoutInternet).Show();

        foreach (var item in e.ConnectionProfiles)
        {
            switch (item)
            {
                case ConnectionProfile.Bluetooth:
                    await Snackbar.Make(activeBluetooth,
                        actionButtonText: string.Empty,
                        visualOptions: snackbarWithInternet).Show();
                    break;
                case ConnectionProfile.Cellular:
                    await Snackbar.Make(activeCell,
                        actionButtonText: string.Empty,
                        visualOptions: snackbarWithInternet).Show();
                    break;
                case ConnectionProfile.Ethernet:
                    await Snackbar.Make(activeEthernet,
                        actionButtonText: string.Empty,
                        visualOptions: snackbarWithInternet).Show();
                    break;
                case ConnectionProfile.WiFi:
                    await Snackbar.Make(activeWifi,
                        actionButtonText: string.Empty,
                        visualOptions: snackbarWithInternet).Show();
                    break;
                default:
                    break;
            }
        }
    }

}
