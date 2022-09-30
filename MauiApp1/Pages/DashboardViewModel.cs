using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.Pages;

[INotifyPropertyChanged]
public partial class DashboardViewModel
{
	[RelayCommand]
	async Task ViewAll()
	{
		await App.Current.MainPage.DisplayAlert("Not Implemented", "Wouldn't it be nice tho?", "Okay");
	}
}

