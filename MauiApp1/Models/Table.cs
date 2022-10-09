using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.Models;

[INotifyPropertyChanged]
public partial class Table
{
    public string Meja_ID { get; set; }

    public string Nomor { get; set; }

    public string Kursi { get; set; }

    public string X { get; set; }

    public string Y { get; set; }

    public string Width { get; set; }

    public string Height { get; set; }
    public string Level { get; set; }
}