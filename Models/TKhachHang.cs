using System;
using System.Collections.Generic;

namespace Web_BTL.Models;

public partial class TKhachHang
{
    public string AccKhachHang { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? MatKhau { get; set; }
}
