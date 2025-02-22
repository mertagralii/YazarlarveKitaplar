namespace YazarlarveKitaplar.Models
{
    public class Yazar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int  Age  { get; set; }
        public List<Kitap>? Kitaplar { get; set; }
    }
}
