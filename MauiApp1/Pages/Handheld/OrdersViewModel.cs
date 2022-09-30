using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Models;
using System.Collections.ObjectModel;

namespace MauiApp1.Pages.Handheld;

[INotifyPropertyChanged]
public partial class OrdersViewModel
{
    [ObservableProperty]
    private ObservableCollection<Order> _orders;

    public OrdersViewModel()
    {
        _orders = new ObservableCollection<Order>(AppData.Orders);
    }
}