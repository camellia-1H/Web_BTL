namespace Web_BTL.Models.PhimModels
{
    public class Phim
    {
        public string MaPhim { get; set; }
        public string? TenPhim { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? TheLoai { get; set; }
        public ICollection<TRap>? MaRaps { get; set; }
    }
}
