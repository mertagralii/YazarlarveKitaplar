using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YazarlarveKitaplar.Data;
using YazarlarveKitaplar.Models;

namespace YazarlarveKitaplar.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var query = from kitap in _context.Kitaplar
                        join yazar in _context.Yazarlar
                        on kitap.YazarId equals yazar.Id
                        select new YazarKitapViewModel
                        {
                            Id = yazar.Id,
                            YazarName = yazar.Name,
                            YazarSurname = yazar.Surname,
                            KitapId = kitap.Id,
                            YazarId = kitap.YazarId,
                            KitapName = kitap.Name,
                            KitapDescription = kitap.Description
                        };

            var yazarlar = _context.Yazarlar.ToList();

            var kitaplar = _context.Kitaplar.ToList();

            var model = new IndexViewModel
            {
                YazarKitapViewModel = query.ToList(),
                Yazarlar = yazarlar,
                Kitaplar = kitaplar
            };


            return View(model);
        }

        
    }
}
