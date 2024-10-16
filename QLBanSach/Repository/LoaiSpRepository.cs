using QLBanSach;
using QLBanSach.Models;
namespace QLBanSach.Repository

{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QlthuVienContext _context;
        public LoaiSpRepository(QlthuVienContext context) 
        { 
            _context = context;
        }
        public TLoaiSach Add(TLoaiSach loaiSp)
        {
            _context.TLoaiSaches.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSach Delete(string maloaiSp)
        {
            throw new NotImplementedException();
        }

        public TLoaiSach Get(string maloaiSp)
        {
            return _context.TLoaiSaches.Find(maloaiSp);
        }

        public IEnumerable<TLoaiSach> GetAllLoaiSp()
        {
            return _context.TLoaiSaches;
        }

        public TLoaiSach Update(TLoaiSach loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
