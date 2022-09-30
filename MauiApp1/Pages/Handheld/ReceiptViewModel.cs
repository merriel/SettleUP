using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.Pages.Handheld;

[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class ReceiptViewModel
{
    [ObservableProperty]
    Order order;

    [RelayCommand]
    async void Done()
    {
        await Shell.Current.GoToAsync("///orders");
    }
}