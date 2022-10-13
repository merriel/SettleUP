using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.Models;

[INotifyPropertyChanged]
public partial class Member
{

    public string Name { get; set; }
    public int Person { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public Table Room{ get; set; }

}