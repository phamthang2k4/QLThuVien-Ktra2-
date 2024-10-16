using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLBanSach.Models;
using System.Diagnostics;
using X.PagedList;

namespace QLBanSach.Controllers
{
    public class HomeController : Controller
    {
        QlthuVienContext db = new QlthuVienContext();
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.TSaches.AsNoTracking().OrderBy(x => x.TenSach);
            PagedList<TSach> lst = new PagedList<TSach>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSach)
        {
            TempData["Message"] = "";
            var chiTietSanPhams = db.TBanSaoSaches.Where(x => x.MaSach == maSach).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xoá được sản phẩm này";
                return RedirectToAction("Index");
            }
            
            db.Remove(db.TSaches.Find(maSach));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xoá";
            return RedirectToAction("Index");
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaNgonNgu = new SelectList(db.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNXB = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TSach sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TSaches.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(sanPham);
        }


        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSach)
        {
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaNgonNgu = new SelectList(db.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNXB = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            var sanPham = db.TSaches.Find(maSach);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TSach sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(sanPham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
