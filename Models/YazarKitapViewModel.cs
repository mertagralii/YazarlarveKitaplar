namespace YazarlarveKitaplar.Models
{
    public class YazarKitapViewModel
    {
        // Yazarlar Tablosu
        public int Id { get; set; }

        public string YazarName { get; set; }

        public string YazarSurname { get; set; }

        // Kitaplar Tablosu
        public int KitapId { get; set; }

        public int YazarId { get; set; }

        public string KitapName { get; set; }

        public string KitapDescription { get; set; }

        public List<Yazar> Yazarlar { get; set; }

        public List<Kitap> Kitaplar { get; set; }
    }
}
