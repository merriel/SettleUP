using System;
using System.Windows.Input;

namespace MauiApp1
{
	public class LoginPageViewModel : BaseViewModel
	{
        public ICommand ICommandNavToHomePage { get; set; }

        public LoginPageViewModel()
		{
            ICommandNavToHomePage = new Command(() => NavigateToHomePage());
        }

        private void NavigateToHomePage()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

