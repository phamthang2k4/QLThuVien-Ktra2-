namespace QLBanSach.Models.ProductModels
{
    public class Product
    {
        public string MaSach { get; set; } = null!;

        public string TenSach { get; set; }

        public string MaLoai { get; set; }

        public double? GiaTriSach { get; set; }

        public string FileAnh { get; set; }
    }
}
