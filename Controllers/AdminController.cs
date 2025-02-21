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
           
            ViewBag.Yazarlar = _context.Yazarlar.Include(y => y.Kitaplar).ToList();
            ViewBag.Kitaplar = _context.Kitaplar.Include(k => k.Yazar).ToList();


            return View();
        }

        [HttpPost]
        public IActionResult InsertKitap(Kitap kitaplar) 
        {
            if (!ModelState.IsValid)
            {
               return RedirectToAction("Index");
            }
            _context.Kitaplar.Add(kitaplar);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateKitap(int Id) 
        {
            var selectedKitap = _context.Kitaplar.Find(Id);

            if (selectedKitap == null) 
            {
                return RedirectToAction("Index");
            }

            return View(selectedKitap); 
        }
        [HttpPost]
        public IActionResult UpdateKitap(Kitap kitaplar)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");

            }

            kitaplar.Name = kitaplar.Name;
            kitaplar.Description = kitaplar.Description;
            kitaplar.YazarId = kitaplar.YazarId;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult DeleteKitap(int Id)
        {
            var selectKitap = _context.Kitaplar.Find(Id);

            if (selectKitap != null) 
            {
                _context.Kitaplar.Remove(selectKitap);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult InsertYazar(Yazar yazar) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _context.Yazarlar.Add(yazar);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult UpdateYazar(int Id)
        {
            var yazar = _context.Yazarlar.Find(Id);

            if (yazar == null)
            {
                return RedirectToAction("Index");
            }

            return View(yazar);
        }

        [HttpPost]
        public IActionResult UpdateYazar(Yazar yazar) 
        {
          
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            yazar.Name = yazar.Name;
            yazar.Surname = yazar.Surname;
            yazar.Age = yazar.Age;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteYazar(int Id)
        {
            var yazar = _context.Yazarlar.Find(Id);

            if (yazar != null)
            {
                _context.Yazarlar.Remove(yazar);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTable(int id) 
        {

            var kitap = _context.Kitaplar
               .Include(k => k.Yazar)
               .FirstOrDefault(k => k.Id == id);

            if (kitap == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Yazarlar = _context.Yazarlar
                .Include(k => k.Kitaplar)
                .ToList();

            return View(kitap);
        }

        [HttpPost]
        public IActionResult UpdateTable(Kitap kitaplar)
        {
           
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            _context.Kitaplar.Update(kitaplar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTable(int Id) 
        {
            var table = _context.Kitaplar.Find(Id);
            if (table != null)
            {
                _context.Kitaplar.Remove(table);
                _context.SaveChanges();
                
            }
           
            return RedirectToAction("Index");

        }
    }
}
