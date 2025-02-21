namespace YazarlarveKitaplar.Models
{
    public class IndexViewModel
    {
        public List<YazarKitapViewModel> YazarKitapViewModel { get; set; }

        public List<Yazar> Yazarlar { get; set; }

        public List<Kitap> Kitaplar { get; set; }
    }
}
