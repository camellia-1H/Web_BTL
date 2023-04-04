using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TPhong
{
    public string MaPhong { get; set; } = null!;

    public string? MaRap { get; set; }

    public virtual TRap? MaRapNavigation { get; set; }

    public virtual ICollection<TGhe> TGhes { get; } = new List<TGhe>();

    public virtual ICollection<TLichChieu> TLichChieus { get; } = new List<TLichChieu>();
}
