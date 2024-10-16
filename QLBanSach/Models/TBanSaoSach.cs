using System;
using System.Collections.Generic;

namespace QLBanSach.Models;

public partial class TBanSaoSach
{
    public string MaBanSao { get; set; } = null!;

    public string? MaSach { get; set; }

    public bool? TrangThai { get; set; }

    public string? TinhTrangSach { get; set; }

    public string? ViTri { get; set; }

    public string? Anh { get; set; }

    public virtual TSach? MaSachNavigation { get; set; }

    public virtual ICollection<TMuonTra> TMuonTras { get; set; } = new List<TMuonTra>();
}
