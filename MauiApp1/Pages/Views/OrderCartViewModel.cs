using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System;
namespace MauiApp1.Pages.Views;

[INotifyPropertyChanged]
public partial class OrderCartViewModel
{
    [ObservableProperty]
    Order order;

    public OrderCartViewModel()
    {
        Order = AppData.Orders.First();
    }

    [RelayCommand]
    async Task PlaceOrder()
    {
        await App.Current.MainPage.DisplayAlert("Not Implemented", "Wouldn't it be cool tho?", "Okay");
    }
}