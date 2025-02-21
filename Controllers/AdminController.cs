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
            var yazarlar = _context.Yazarlar.Include(y => y.Kitaplar).ToList();
            var kitaplar = _context.Kitaplar.Include(k => k.Yazar).ToList();

            ViewBag.Yazarlar = yazarlar;
            ViewBag.Kitaplar = kitaplar;


            return View();
        }

        [HttpPost]
        public IActionResult InsertKitap(Kitap kitaplar) 
        {
            _context.Kitaplar.Add(kitaplar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateKitap(int Id) 
        {
            var selectedKitap = _context.Kitaplar.Find(Id);

            return View(selectedKitap); 
        }
        [HttpPost]
        public IActionResult UpdateKitap(Kitap kitaplar)
        {
            var updateKitap = _context.Kitaplar.Find(kitaplar.Id);
            if (updateKitap != null)
            {
                updateKitap.Name = kitaplar.Name;
                updateKitap.Description = kitaplar.Description;
                updateKitap.YazarId = kitaplar.YazarId;
                _context.SaveChanges();
               
            }
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
        public IActionResult UpdateYazar(Yazar yazar) 
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
        [HttpGet]
        public IActionResult UpdateTable(int Id) 
        {

            var findTable = _context.Kitaplar.Find(Id);

            var yazarlar = _context.Yazarlar.ToList();

            var model = new UpdateTableViewModel
            {
                Yazarlar = yazarlar,
                Kitap = findTable
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateTable(Kitap kitaplar)
        {
            var updateTable = _context.Kitaplar.Find(kitaplar.Id);
            if (updateTable != null)
            {
                updateTable.Name = kitaplar.Name;
                updateTable.Description = kitaplar.Description;
                updateTable.YazarId = kitaplar.YazarId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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
