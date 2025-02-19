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
            return View();
        }

        
    }
}
