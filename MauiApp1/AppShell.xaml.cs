using MauiApp1.Pages;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
       
        if (!Preferences.ContainsKey("User_ID"))
        {
            Login();
        }

    }

    private void InitRoutes()
    {
        Routing.RegisterRoute(nameof(AddProductView), typeof(AddProductView));
    }

    private async void Login()
    {
       await Navigation.PushAsync (new LoginPage());
        // await Shell.Current.Navigation.PushAsync(LoginPage);
    }

    private string selectedRoute;
    public string SelectedRoute
    {
        get { return selectedRoute; }
        set
        {
            selectedRoute = value;
            OnPropertyChanged();
        }
    }
    async void OnMenuItemChanged(System.Object sender, CheckedChangedEventArgs e)
    {
        if (!String.IsNullOrEmpty(selectedRoute))
            await Shell.Current.GoToAsync($"//{selectedRoute}");
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        Preferences.Default.Clear();
        await Navigation.PushAsync(new LoginPage());
    }
}
