using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace MauiApp1.Pages.Views;
public class Commons : INotifyPropertyChanged
{
    private static Commons _instance = null;

    protected Commons()
    {
    }
    public static Commons GetInstance()
    {
        if (_instance == null)
            _instance = new Commons();

        return _instance;
    }

    private string _title;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Title
    {
        get { return _title; }
        set
        {
            if (_title == value)
                return;
            _title = value;
            OnPropertyChanged("Title");
        }
    }

    public void Load()
    {
    }

    public virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventArgs ea = new PropertyChangedEventArgs(propertyName);
        if (PropertyChanged != null)
            PropertyChanged(this, ea);
    }

}