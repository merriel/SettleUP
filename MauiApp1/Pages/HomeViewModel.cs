using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Pages.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp1.Pages;

[INotifyPropertyChanged]
public partial class HomeViewModel
{


    [ObservableProperty]
    ObservableCollection<Table> _meja;
    public Commons CommonData { get; private set; }
    public HomeViewModel()
    {
        get_meja();
        CommonData = Commons.GetInstance();
    }

    

    private string myTable;
    public string MyProperty //Bind to this in your View1
    {
        get
        {
            return myTable;
        }
        set
        {
            myTable = value;
        }
    }



    [RelayCommand]
    async Task Preferences()
    {
        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}?sub=appearance");
    }

 

    public async Task get_meja()
    {
        try
        {

            var myHttpClient = new HttpClient();
            Uri uri = new Uri(Config.TableAccess);
            var response = await myHttpClient.GetStringAsync(uri);

            if (response != "[]")
            {
                string result = response.Substring(1);
                var json = JsonConvert.DeserializeObject<List<Table>>(result);
                Meja = new ObservableCollection<Table>();
                foreach (Table item in json)
                {
                    Meja.Add(new Table
                    {
                        Meja_ID = item.Meja_ID,
                        Nomor = item.Nomor,
                        X = item.X,
                        Y = item.Y,
                        Height = item.Height,
                        Width = item.Width,
                        Level = item.Level
                    });
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(null, "Data not Found", "ok");
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