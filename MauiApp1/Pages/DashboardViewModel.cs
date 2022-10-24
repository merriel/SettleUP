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
       get_grup();
       get_masterbarang();
        _products = new ObservableCollection<Item>(
            AppData.Items.Where(x => x.Category == ItemCategory.Noodles).ToList()
        );
        
    }
    [ObservableProperty]
    ObservableCollection<ItemGrup> _grups;
    public async Task get_grup()
    {
        try
        {

            var myHttpClient = new HttpClient();
            Uri uri = new Uri(Config.GrupAccess);
            var response = await myHttpClient.GetStringAsync(uri);

            if (response != "[]")
            {
                string result = response.Substring(1);
                var json = JsonConvert.DeserializeObject<List<ItemGrup>>(result);
                Grups = new ObservableCollection<ItemGrup>();
                foreach (ItemGrup item in json)
                {
                    Grups.Add(new ItemGrup
                    {
                        Grup = item.Grup
                    });
                    //System.Diagnostics.Debug.WriteLine(item.Grup);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(null, "Data not Found", "ok");
            }
            myHttpClient.Dispose();
        }

        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
            System.Diagnostics.Debug.WriteLine(e);
        }
    }

    [ObservableProperty]
    ObservableCollection<ItemBarang> _barang;
    public async Task get_masterbarang()
    {
        try
        {

            var myHttpClient = new HttpClient();
            Uri uri = new Uri(Config.MasterBarangAccess);
            var response = await myHttpClient.GetStringAsync(uri);

            if (response != "[]")
            {
                string result = response.Substring(1);
                var json = JsonConvert.DeserializeObject<List<ItemBarang>>(result);
                Barang = new ObservableCollection<ItemBarang>();
                foreach (ItemBarang item in json)
                {
                    Barang.Add(new ItemBarang
                    {
                        MasterBarang_ID = item.MasterBarang_ID,
                        Nama = item.Nama,
                        NamaLain = item.NamaLain,
                        Grup = item.Grup,
                        SubGrup = item.SubGrup,
                        Barcode = item.Barcode,
                        Satuan = item.Satuan,
                        MinimumStok = item.MinimumStok,
                        MaksimumStok = item.MaksimumStok,
                        ReTransaksiPoint = item.ReTransaksiPoint,
                        ToleranceSupplier = item.ToleranceSupplier,
                        HargaBeli = item.HargaBeli,
                        HargaBeliTerakhir = item.HargaBeliTerakhir,
                        HargaJual = item.HargaJual,
                        Warna = item.Warna,
                        StatusPaket = item.StatusPaket,
                        StatusAktif = item.StatusAktif,
                        StatusInventory = item.StatusInventory,
                        StatusOpenItem = item.StatusOpenItem,
                        StatusResep = item.StatusResep,
                        StatusJual = item.StatusJual,
                        StatusOutOfOrder = item.StatusOutOfOrder,
                        StatusPosisiStok = item.StatusPosisiStok
                    });
                    ///System.Diagnostics.Debug.WriteLine(item.Nama);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(null, "Data not Found", "ok");
            }
            myHttpClient.Dispose();
        }

        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
            System.Diagnostics.Debug.WriteLine(e);
        }
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