using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Pages.Handheld;

[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class TipViewModel
{
    [ObservableProperty]
    Models.Order order;

    [ObservableProperty]
    double tip;

    partial void OnTipChanged(double value)
    {
        order.Tip = value;
        OnPropertyChanged(nameof(Order));
    }

    [RelayCommand]
    async void Continue()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", order }
        };
        await Shell.Current.GoToAsync($"{nameof(PayPage)}", navigationParameter);
    }
}   