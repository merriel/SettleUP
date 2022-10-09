using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.Models;

[INotifyPropertyChanged]
public partial class Config
{

    public static string IP = "192.168.43.234";
    public static string LoginAccess = "http://" + IP + "/SettleUP/android/login_user.php";
    public static string TableAccess = "http://" + IP + "/SettleUP/android/get_table.php";
    public string Password { get; set; }
    public string Level { get; set; }
    public string Karyawan_ID{ get; set; }

}