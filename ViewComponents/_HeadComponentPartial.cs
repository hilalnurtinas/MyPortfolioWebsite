using Microsoft.AspNetCore.Mvc;


namespace MyPortfolioWebsite.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
