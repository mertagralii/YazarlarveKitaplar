namespace YazarlarveKitaplar.Models
{
    public class Kitap
    {
        public int Id { get; set; }

        public int YazarId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Yazar Yazar { get; set; }


    }
}
