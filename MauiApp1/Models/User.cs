using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.Models;

[INotifyPropertyChanged]
public partial class User
{

    public string User_ID { get; set; }
    public string Nama { get; set; }
    public string Password { get; set; }
    public string Level { get; set; }
    public string Karyawan_ID{ get; set; }

}