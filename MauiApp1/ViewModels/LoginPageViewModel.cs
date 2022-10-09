
using MauiApp1.Models;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows.Input;

namespace MauiApp1
{
	public class LoginPageViewModel : BaseViewModel
	{
        public ICommand ICommandNavToHomePage { get; set; }

        public Command LoginCommand { get; }
        INavigation Inav;
        public LoginPageViewModel(INavigation Inavigation)
		{
            ICommandNavToHomePage = new Command(() => NavigateToHomePage());
            this.Inav = Inavigation;
            LoginCommand = new Command(OnLoginClicked);
        }

        private string val;
        public string Value
        {
            get { return val; }
            set
            {
                val = value;
            }
        }

        private async void OnLoginClicked(object obj)
        {
            await LoginUserAsync(Value);

        }

        private void NavigateToHomePage()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task LoginUserAsync(string userid)
        {
            try
            {
                var data = new User
                {
                    User_ID = userid
                };

                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var myHttpClient = new HttpClient();
                Uri uri = new Uri(Config.LoginAccess + "?User_ID=" + userid);
                var response = await myHttpClient.GetStringAsync(uri);

                if (response != "[]")
                {
                    string result = response.Substring(1);
                    var json = JsonConvert.DeserializeObject<List<User>>(result);
                    foreach (User item in json)
                    {
                        Preferences.Default.Set("User_ID", item.User_ID);
                        Preferences.Default.Set("Name", item.Nama);
                        //if result insert into kehadiran table then open take picture page, else show exception / alertdialog
                        //for now return from API qrcode = null, _POST on PHP not working
                         await Inav.PopAsync();
                        //await Inav.PushAsync(new AppShell());
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(null, "Email not found, please register", "ok");
                }
                myHttpClient.Dispose();
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

    }
}

