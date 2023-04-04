using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TRap
{
    public string MaRap { get; set; } = null!;

    public string? TenRap { get; set; }

    public string? DiaChi { get; set; }

    public string? AnhRap { get; set; }

    public virtual ICollection<TPhong> TPhongs { get; } = new List<TPhong>();

    public virtual ICollection<TPhim> MaPhims { get; } = new List<TPhim>();
}
