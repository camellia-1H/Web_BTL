using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_BTL.Models;
using Web_BTL.Models.PhimModels;
namespace Web_BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimAPIController : ControllerBase
    {
        TheTicketMovieContext db = new TheTicketMovieContext();
        [HttpGet]
        public IEnumerable<Phim> GetAllPhims()
        {
            var phim = (from p in db.TPhims select new Phim
            {
                MaPhim = p.MaPhim,
                TenPhim = p.TenPhim,
                AnhDaiDien = p.AnhDaiDien,
                TheLoai = p.TheLoai,
                MaRaps = p.MaRaps
            }).ToList();
            return phim;
        }
        [HttpGet("{maRap}")]
        public IEnumerable<Phim> GetPhimsByMaRap(string maRap)
        {
            var phim = (from p in db.TPhims
                        where p.MaRaps.Any(mr => mr.MaRap == maRap)
                        select new Phim
                        {
                            MaPhim = p.MaPhim,
                            TenPhim = p.TenPhim,
                            AnhDaiDien = p.AnhDaiDien,
                            TheLoai = p.TheLoai,
                            MaRaps = p.MaRaps
                        }).ToList();
            return phim;
        }
    }
}
