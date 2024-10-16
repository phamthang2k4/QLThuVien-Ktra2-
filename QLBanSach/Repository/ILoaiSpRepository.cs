using QLBanSach.Models;
namespace QLBanSach.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSach Add(TLoaiSach loaiSp);
        TLoaiSach Update(TLoaiSach loaiSp);
        TLoaiSach Delete(String maloaiSp);
        TLoaiSach Get(String maloaiSp);
        IEnumerable<TLoaiSach> GetAllLoaiSp();
    }
}
