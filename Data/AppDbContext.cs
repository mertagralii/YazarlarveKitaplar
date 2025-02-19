using Microsoft.EntityFrameworkCore;
using YazarlarveKitaplar.Models;

namespace YazarlarveKitaplar.Data
{
    
        public class AppDbContext :DbContext
        {
            public DbSet<Kitaplar> Kitaplar { get; set; }

            public DbSet<Yazarlar> Yazarlar { get; set; }

            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        }
    
}
