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

    private void Entry_Completed(object sender, EventArgs e)
    {
        ((LoginPageViewModel)this.BindingContext).OnLoginClicked(sender);
    }
}
