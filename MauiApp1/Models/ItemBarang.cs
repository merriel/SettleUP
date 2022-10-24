using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.Models;

[INotifyPropertyChanged]
public partial class ItemBarang
{
    public string MasterBarang_ID { get; set; }
    public string Nama { get; set; }
    public string NamaLain { get; set; }
    public string Grup { get; set; }
    public string SubGrup{ get; set; }
    public string Barcode { get; set; }
    public string Satuan { get; set; }
    public string MinimumStok { get; set; }
    public string MaksimumStok { get; set; }
    public string ReTransaksiPoint{ get; set; }
    public string ToleranceSupplier { get; set; }
    public string HargaBeli { get; set; }
    public string HargaBeliTerakhir { get; set; }
    public string HargaJual { get; set; }
    public string Warna { get; set; }
    public string StatusPaket { get; set; }
    public string StatusAktif { get; set; }
    public string StatusInventory { get; set; }
    public string StatusOpenItem { get; set; }
    public string StatusResep { get; set; }
    public string StatusJual { get; set; }
    public string StatusOutOfOrder { get; set; }
    public string StatusPosisiStok { get; set; }
}