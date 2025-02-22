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
                TempData["InsertKitapWrong"] = "Kitap Ekleme İşlemi Gerçekleştirilemedi.";
                return RedirectToAction("Index");
            }
            _context.Kitaplar.Add(kitaplar);
            _context.SaveChanges();
            TempData["InsertKitap"] = "Kitap Ekleme İşlemi Başarıyla Gerçekleştirildi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateKitap(int Id) 
        {
            var selectedKitap = _context.Kitaplar.Find(Id);

            if (selectedKitap == null) 
            {
                TempData["UpdateKitapGetWrong"] = "Kitap'a ait bilgi bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(selectedKitap); 
        }
        [HttpPost]
        public IActionResult UpdateKitap(Kitap kitaplar)
        {

            if (!ModelState.IsValid)
            {
                TempData["UpdateKitapWrong"] = "Kitap Güncelleme İşlemi Gerçekleştirilemedi.";
                return RedirectToAction("Index");

            }
            var selectedKitap = _context.Kitaplar.Find(kitaplar.Id);

            selectedKitap.Name = kitaplar.Name;
            selectedKitap.Description = kitaplar.Description;
            selectedKitap.YazarId = kitaplar.YazarId;
            _context.SaveChanges();
            TempData["UpdateKitap"] = "Kitap Güncelleme İşlemi Başarıyla Gerçekleştirildi.";
            return RedirectToAction("Index");

        }
        public IActionResult DeleteKitap(int Id)
        {
            var selectKitap = _context.Kitaplar.Find(Id);

            if (selectKitap != null) 
            {
                
                _context.Kitaplar.Remove(selectKitap);
                _context.SaveChanges();
                TempData["DeleteKitap"] = "Kitap Silme İşlemi Başarıyla Gerçekleştirildi.";
                return RedirectToAction("Index");
            }
            TempData["DeleteKitapWrong"] = "Kitap Silme İşlemi  Gerçekleştirilemedi.";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult InsertYazar(Yazar yazar) 
        {
            if (!ModelState.IsValid)
            {
                TempData["InsertYazarWrong"] = "Yazar Ekleme İşlemi  Gerçekleştirilemedi.";
                return RedirectToAction("Index");
            }

            _context.Yazarlar.Add(yazar);
            _context.SaveChanges();
            TempData["InsertYazar"] = "Yazar Ekleme İşlemi  Başarıyla Gerçekleştirildi.";
            return RedirectToAction("Index");
        }

        public IActionResult UpdateYazar(int Id)
        {
            var yazar = _context.Yazarlar.Find(Id);

            if (yazar == null)
            {
                TempData["UpdateYazarGetWrong"] = "Yazar ait bilgi Bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(yazar);
        }

        [HttpPost]
        public IActionResult UpdateYazar(Yazar yazar) 
        {
          
            if (!ModelState.IsValid)
            {
                TempData["UpdateYazarWrong"] = "Yazar Güncelleme İşlemi  Gerçekleştirilemedi.";

                return RedirectToAction("Index");
            }
            var selectedYazar = _context.Yazarlar.Find(yazar.Id);

            selectedYazar.Name = yazar.Name;
            selectedYazar.Surname = yazar.Surname;
            selectedYazar.Age = yazar.Age;
            _context.Yazarlar.Update(selectedYazar);
            _context.SaveChanges();

            TempData["UpdateYazar"] = "Yazar Güncelleme İşlemi Başarıyla  Gerçekleştirildi.";

            return RedirectToAction("Index");
        }

        public IActionResult DeleteYazar(int Id)
        {
            var yazar = _context.Yazarlar.Find(Id);

            if (yazar != null)
            {
                _context.Yazarlar.Remove(yazar);
                _context.SaveChanges();
                TempData["DeleteYazar"] = "Silme İşlemi Başarıyla Gerçekleştirildi.";
                return RedirectToAction("Index");
            }
            TempData["DeleteYazarWrong"] = "Silme İşlemi  Gerçekleştirilemedi.";

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
                TempData["UpdateTableGetWrong"] = "Seçilen ürüne ait bilgi bulunamadı.";
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
                TempData["UpdateTableWrong"] = "Güncelleme işlemi gerçekleştirilemedi.";
                return RedirectToAction("Index");
            }
            _context.Kitaplar.Update(kitaplar);
            _context.SaveChanges();
            TempData["UpdateTable"] = "Güncelleme işlemi başarıyla gerçekleştiriledi.";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTable(int Id) 
        {
            var table = _context.Kitaplar.Find(Id);

            if (table != null)
            {
                _context.Kitaplar.Remove(table);
                _context.SaveChanges();
                TempData["DeleteTable"] = "Silme işlemi başarıyla gerçekleştirildi.";
                return RedirectToAction("Index");
            }

            TempData["DeleteTableWrong"] = "Silme işlemi gerçekleştirilemedi.";

            return RedirectToAction("Index");

        }
    }
}
