using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();


        public IViewComponentResult Invoke()
        {
            var values = portfolioContext.Skill.ToList();
            
            return View(values);
        }
    }
}
