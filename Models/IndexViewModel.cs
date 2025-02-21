namespace YazarlarveKitaplar.Models
{
    public class IndexViewModel
    {
        public List<YazarKitapViewModel> YazarKitapViewModel { get; set; }

        public List<Yazarlar> Yazarlar { get; set; }

        public List<Kitaplar> Kitaplar { get; set; }
    }
}
