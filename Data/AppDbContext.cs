using Microsoft.EntityFrameworkCore;
using YazarlarveKitaplar.Models;

namespace YazarlarveKitaplar.Data
{
    
        public class AppDbContext :DbContext
        {
            public DbSet<Kitap> Kitaplar { get; set; }

            public DbSet<Yazar> Yazarlar { get; set; }

            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        }
    
}
