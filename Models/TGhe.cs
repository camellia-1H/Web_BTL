using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TGhe
{
    public string MaGhe { get; set; } = null!;

    public string? LoaiGhe { get; set; }

    public string? ViTri { get; set; }

    public string TrangThaiGhe { get; set; } = null!;

    public string? MaPhong { get; set; }

    public virtual TPhong? MaPhongNavigation { get; set; }
}
