using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System;
using System.ComponentModel;
using Xamarin.Google.Crypto.Tink.Proto;

namespace MauiApp1.Pages.Views;

[INotifyPropertyChanged]
public partial class OrderCartViewModel
{
    [ObservableProperty]
    Order order;
    public Commons CommonData { get; private set; }
    public INavigation Navigation { get; set; }
    public OrderCartViewModel(INavigation navigation)
    {
        Order = AppData.Orders.First();
        this.Navigation = navigation;
        CommonData = Commons.GetInstance();
    }

    private string myTable;
    public string PropertyTable //Bind to this in your View1
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
    async Task PlaceOrder()
    {
        await Navigation.PushAsync(new DashboardPage());
        //await App.Current.MainPage.DisplayAlert("Not Implemented", "Wouldn't it be cool tho?", "Okay");
    }
}