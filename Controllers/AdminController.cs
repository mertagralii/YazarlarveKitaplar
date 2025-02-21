using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YazarlarveKitaplar.Data;
using YazarlarveKitaplar.Models;

namespace YazarlarveKitaplar.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
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

        
        public IActionResult InsertKitap() 
        {
           
            return RedirectToAction("Index");
        }

        public IActionResult UpdateKitap() 
        {
            return View(); 
        }
        public IActionResult DeleteKitap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertYazar(Yazarlar yazar) 
        {
            _context.Yazarlar.Add(yazar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateYazar(int Id)
        {
            var yazar = _context.Yazarlar.Find(Id);
            return View(yazar);
        }

        [HttpPost]
        public IActionResult UpdateYazar(Yazarlar yazar) 
        {
           var updateYazar = _context.Yazarlar.Find(yazar.Id);
            if (updateYazar != null)
            {
                updateYazar.Name = yazar.Name;
                updateYazar.Surname = yazar.Surname;
                updateYazar.Age = yazar.Age;
                _context.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        public IActionResult DeleteYazar(int Id)
        {
            var yazar = _context.Yazarlar.Find(Id);
            _context.Yazarlar.Remove(yazar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTable() 
        {
            return View();
        }
        public IActionResult DeleteTable(int Id) 
        {
            var table = _context.Kitaplar.Find(Id);
            _context.Kitaplar.Remove(table);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
