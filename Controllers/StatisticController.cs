using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        public IActionResult Index()
        {
            ViewBag.v1 = context.Skill.Count();
            ViewBag.v2 = context.Message.Count();
            ViewBag.v3 = context.Message.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = context.Message.Where(x => x.IsRead == true).Count();


            return View();
        }
    }
}
