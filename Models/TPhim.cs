using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TPhim
{
    public string MaPhim { get; set; } = null!;

    public string? TenPhim { get; set; }

    public string? TheLoai { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? Background { get; set; }

    public string? ThoiLuong { get; set; }

    public string? DaoDien { get; set; }

    public string? DienVienChinh { get; set; }

    public string? NoiDung { get; set; }

    public string AccNhanVien { get; set; } = null!;

    public virtual ICollection<TLichChieu> MaLichChieus { get; } = new List<TLichChieu>();

    public virtual ICollection<TRap> MaRaps { get; } = new List<TRap>();
}
