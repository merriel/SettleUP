using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System;
using System.Collections.ObjectModel;
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

    private string name_member;
    public string Name_Member //Bind to this in your View1
    {
        get
        {
            return name_member;
        }
        set
        {
            name_member= value;
        }
    }

    private int jml_person;
    public int Jml_Person //Bind to this in your View1
    {
        get
        {
            return jml_person;
        }
        set
        {
            jml_person = value;
        }
    }

    private string phone_number;
    public string Phone_Number //Bind to this in your View1
    {
        get
        {
            return phone_number;
        }
        set
        {
            phone_number = value;
        }
    }
    private string address;
    public string Address //Bind to this in your View1
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    [ObservableProperty]
    ObservableCollection<Member> info_member;

    [RelayCommand]
    async Task PlaceOrder()
    {
        info_member = new ObservableCollection<Member>();
        info_member.Add(new Member
        {
            Name = Name_Member,
            Person = Jml_Person,
            Phone = Phone_Number,
            Address = Address,
            Room = CommonData.RoomSelected
        });
        
        await Navigation.PushAsync(new DashboardPage(info_member));
        //await App.Current.MainPage.DisplayAlert("Not Implemented", "Wouldn't it be cool tho?", "Okay");
    }
}