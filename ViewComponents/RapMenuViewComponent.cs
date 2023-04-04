using Microsoft.AspNetCore.Mvc;
using Web_BTL.Responsitory;

namespace Web_BTL.ViewComponents
{
    public class RapMenuViewComponent : ViewComponent
    {
        private readonly IRapResponsitory _rap;
        public RapMenuViewComponent(IRapResponsitory rapResponsitory)
        {
            _rap = rapResponsitory;
        }
        public IViewComponentResult Invoke()
        {
            var rap = _rap.GetAllRap().OrderBy(x => x.MaRap);
            return View(rap);
        }
    }
}
