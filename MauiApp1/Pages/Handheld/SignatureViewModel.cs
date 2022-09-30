using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Messages;
using MauiApp1.Models;

namespace MauiApp1.Pages.Handheld;

[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class SignatureViewModel
{
    [ObservableProperty]
    Order order;
    
    [RelayCommand]
    async Task Done()
    {
        WeakReferenceMessenger.Default.Send<SaveSignatureMessage>(
            new SaveSignatureMessage(order.Table)
        );

        var navigationParameter = new Dictionary<string, object>
        {
            { "Order", order }
        };
        await Shell.Current.GoToAsync($"{nameof(ReceiptPage)}", navigationParameter);
    }

    [RelayCommand]
    void Clear()
    {
        WeakReferenceMessenger.Default.Send<ClearSignatureMessage>(
            new ClearSignatureMessage(true)
        ); ;
    }
}