using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace MauiApp1.Pages;

[INotifyPropertyChanged]
public partial class DashboardViewModel
{
    [ObservableProperty]
    ObservableCollection<Item> _products;

    [ObservableProperty]
    string category = ItemCategory.Noodles.ToString();

    partial void OnCategoryChanged(string cat)
    {
        ItemCategory category = (ItemCategory)Enum.Parse(typeof(ItemCategory), cat);
        _products = new ObservableCollection<Item>(
            AppData.Items.Where(x => x.Category == category).ToList()
        );
        OnPropertyChanged(nameof(Products));
    }

    public DashboardViewModel()
    {
        _products = new ObservableCollection<Item>(
            AppData.Items.Where(x => x.Category == ItemCategory.Noodles).ToList()
        );
    }

    [RelayCommand]
    async Task Preferences()
    {
        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}?sub=appearance");
    }

    [RelayCommand]
    async Task AddProduct()
    {
        MessagingCenter.Send<DashboardViewModel, string>(this, "action", "add");
    }
}