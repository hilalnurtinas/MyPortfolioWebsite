using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class PortfolioController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult ProjectList()
        {
            var value = context.Portfolio.ToList();
            return View(value);
        }


        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Portfolio portfolio)
        {
            context.Portfolio.Add(portfolio);
            context.SaveChanges();

            return RedirectToAction("ProjectList");

        }

        public IActionResult DeleteProject(int id)
        {
            var value = context.Portfolio.Find(id);
            context.Portfolio.Remove(value);
            context.SaveChanges();

            return RedirectToAction("ProjectList");
        }


        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var Portfolio = context.Portfolio.Find(id);
            if (Portfolio == null)
            {
                return NotFound();
            }
            return View(Portfolio);
        }

        [HttpPost]
        public JsonResult UpdateProject(Portfolio model)
        {
            if (ModelState.IsValid)
            {
                var Portfolio = context.Portfolio.FirstOrDefault(s => s.PortfolioID == model.PortfolioID);
                if (Portfolio != null)
                {
                    Portfolio.Title = model.Title;
                    Portfolio.ImageUrl = model.ImageUrl;
                    Portfolio.Url = model.Url;
                    Portfolio.Description = model.Description;
                    

                    context.SaveChanges();

                    return Json(new { success = true, message = "Portfolio updated successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Portfolio not found!" });
                }
            }
            return Json(new { success = false, message = "Invalid data!" });
        }
    }
}
