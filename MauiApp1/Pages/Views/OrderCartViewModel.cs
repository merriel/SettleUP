using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System;
using System.ComponentModel;

namespace MauiApp1.Pages.Views;

[INotifyPropertyChanged]
public partial class OrderCartViewModel
{
    [ObservableProperty]
    Order order;


    public INavigation Navigation { get; set; }
    public OrderCartViewModel(INavigation navigation)
    {
        Order = AppData.Orders.First();
        this.Navigation = navigation;
    }

    [RelayCommand]
    async Task PlaceOrder()
    {
        await Navigation.PushAsync(new DashboardPage());
        //await App.Current.MainPage.DisplayAlert("Not Implemented", "Wouldn't it be cool tho?", "Okay");
    }
}