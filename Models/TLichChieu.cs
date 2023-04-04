using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TLichChieu
{
    public string MaLichChieu { get; set; } = null!;

    public DateTime? ThoiGianChieu { get; set; }

    public DateTime? ThoiGianKetThuc { get; set; }

    public string? MaVe { get; set; }

    public string? MaPhong { get; set; }

    public virtual TPhong? MaPhongNavigation { get; set; }

    public virtual TVe? MaVeNavigation { get; set; }

    public virtual ICollection<TPhim> MaPhims { get; } = new List<TPhim>();
}
