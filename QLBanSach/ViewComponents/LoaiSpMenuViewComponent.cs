using Microsoft.AspNetCore.Mvc;
using QLBanSach.Repository;
namespace QLBanSach.ViewComponents
{
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp=_loaiSp.GetAllLoaiSp().OrderBy(x=>x.MaLoai);
            return View(loaisp);
        }
    }
}
