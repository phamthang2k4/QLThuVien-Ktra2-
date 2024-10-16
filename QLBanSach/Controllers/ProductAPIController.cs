using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBanSach.Models;
using QLBanSach.Models.ProductModels;


namespace ThucHanhWebMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlthuVienContext db = new QlthuVienContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            var sanPham=(from p in db.TSaches select new Product
            {
                MaSach = p.MaSach,
                TenSach = p.TenSach,
                MaLoai = p.MaLoai,
                GiaTriSach = p.GiaTriSach,
                FileAnh = p.FileAnh
            }).ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {
            var sanPham = (from p in db.TSaches
                           where p.MaLoai==maLoai
                           select new Product
                           {
                               MaSach = p.MaSach,
                               TenSach = p.TenSach,
                               MaLoai = p.MaLoai,
                               GiaTriSach = p.GiaTriSach,
                               FileAnh = p.FileAnh
                           }).ToList();
            return sanPham;
        }

    }
}
