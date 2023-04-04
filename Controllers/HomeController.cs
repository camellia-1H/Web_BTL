using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Web_BTL.Models;
using Web_BTL.Models.PhimModels;
using Web_BTL.Models.PhimLichModels;
using X.PagedList;

namespace Web_BTL.Controllers
{
    public class HomeController : Controller
    {
        TheTicketMovieContext db = new TheTicketMovieContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        
        public IActionResult Index()
        {
            var listphim = db.TPhims.ToList();
            ViewBag.listphim = listphim;
            var phims = db.TPhims.Include(p => p.MaLichChieus);
            var lichs = db.TLichChieus.Include(l => l.MaPhims);

            return View(new PhimLichModels { Phims = phims, Lichs = lichs });
        }

        public IActionResult ChiTietPhim(string maPhim)
        {
            var phim = db.TPhims.SingleOrDefault(x => x.MaPhim == maPhim);
            return View(phim);
        }

        public IActionResult PhimTheoRap(string marap)
        {
            var listphim = db.TPhims.ToList();
            ViewBag.listphim = listphim;
            var phimLichData = new PhimLichModels
            {
                Phims = db.TPhims.Include(p => p.MaLichChieus).AsNoTracking().Where(x => x.MaRaps.Any(m => m.MaRap == marap)).ToList(),
                Lichs = db.TLichChieus.Include(l => l.MaPhims),
            };

            return View(phimLichData);
           // var listphim = db.TPhims.AsNoTracking().Where(x => x.MaRaps.Any(m => m.MaRap == marap)).OrderBy(x => x.TenPhim);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
