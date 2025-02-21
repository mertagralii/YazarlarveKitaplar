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
          var query = _context.Kitaplar
                 .Join(_context.Yazarlar,
                              k => k.YazarId,
                              y => y.Id,
                              (k, y) => new YazarKitapViewModel
                              {
                                  Id = y.Id,
                                  YazarName = y.Name,
                                  YazarSurname = y.Surname,
                                  KitapId = k.Id,
                                  YazarId = k.YazarId,
                                  KitapName = k.Name,
                                  KitapDescription = k.Description
                              });

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

        [HttpPost]
        public IActionResult InsertKitap(Kitaplar kitaplar) 
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
        public IActionResult UpdateKitap(Kitaplar kitaplar)
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
        public IActionResult UpdateTable(Kitaplar kitaplar)
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
