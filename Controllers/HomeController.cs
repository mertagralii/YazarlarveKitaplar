using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var yazarlar = _context.Yazarlar.Include(y => y.Kitaplar).ToList();
            var kitaplar = _context.Kitaplar.Include(k => k.Yazar).ToList();

            ViewBag.Yazarlar = yazarlar;
            ViewBag.Kitaplar = kitaplar;


            return View();
        }

        
    }
}
