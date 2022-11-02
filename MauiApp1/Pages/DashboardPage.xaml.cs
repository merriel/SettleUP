
using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Messages;
using MauiApp1.Models;
using System.Collections.ObjectModel;
using static Android.Graphics.Paint;

namespace MauiApp1.Pages;

public partial class DashboardPage : ContentPage
{


    public DashboardPage(ObservableCollection<Member> member)
    {
        InitializeComponent();

       
    }

    void MenuFlyoutItem_ParentChanged(System.Object sender, System.EventArgs e)
    {
        if (sender is BindableObject bo)
            bo.BindingContext = this.BindingContext;
    }



    public void NavSubContent(bool show)
    {
        var displayWidth = DeviceDisplay.Current.MainDisplayInfo.Width;

        if (show)
        {
            var addForm = new AddProductView();
            PageGrid.Add(addForm, 1);
            Grid.SetRowSpan(addForm, 3);
            // translate off screen right
            addForm.TranslationX = displayWidth - addForm.X;
            addForm.TranslateTo(0, 0, 800, easing: Easing.CubicOut);
        }
        else
        {
            // remove the product window

            var view = (AddProductView)PageGrid.Children.Where(v => v.GetType() == typeof(AddProductView)).SingleOrDefault();

            var x = DeviceDisplay.Current.MainDisplayInfo.Width;
            view.TranslateTo(displayWidth - view.X, 0, 800, easing: Easing.CubicIn);

            if (view != null)
                PageGrid.Children.Remove(view);

        }
    }



    private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
    {
        var grupbutton = ((RadioButton)sender);
        var selectedgrup = grupbutton.Content;
        ((DashboardViewModel)this.BindingContext).CategoryChanged(selectedgrup.ToString());

    }

    private void Entry_Completed(object sender, EventArgs e)
    {
        
    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
      
        ((DashboardViewModel)this.BindingContext).SearchChanged();
    }
}