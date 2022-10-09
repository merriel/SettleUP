using MauiApp1.Models;

namespace MauiApp1;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        BindingContext = new LoginPageViewModel(Navigation);
    }

    public bool IsLogedIn { get; set; }

    
    protected override bool OnBackButtonPressed() { return true; }
}
