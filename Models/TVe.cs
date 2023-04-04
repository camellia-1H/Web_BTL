using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TVe
{
    public string MaVe { get; set; } = null!;

    public string? TenVe { get; set; }

    public string GiaTien { get; set; } = null!;

    public string? MaPhim { get; set; }

    public string? AccKhachHang { get; set; }

    public string? MaGhe { get; set; }

    public virtual ICollection<TLichChieu> TLichChieus { get; } = new List<TLichChieu>();
}
