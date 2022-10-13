using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Pages.Views;
[INotifyPropertyChanged]
public partial class MasterItemViewModel
{
    [ObservableProperty]
    Order order;

    public MasterItemViewModel()
    {
        Order = AppData.Orders.First();
    }

    [RelayCommand]
    async Task PlaceOrder()
    {
        await App.Current.MainPage.DisplayAlert("Not Implemented", "Wouldn't it be cool tho?", "Okay");
    }
}