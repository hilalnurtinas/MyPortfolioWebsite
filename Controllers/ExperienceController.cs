using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult ExperienceList()
        {
            var value = context.Experience.ToList(); 
            return View(value); 
        }

        
        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
           context.Experience.Add(experience);
           context.SaveChanges();
           
            return RedirectToAction("ExperienceList");
            
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = context.Experience.Find(id);
            context.Experience.Remove(value);
            context.SaveChanges();
            
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = context.Experience.FirstOrDefault(e => e.ExperienceID == id);

            return View(experience);
        }


        [HttpPost]
        public JsonResult UpdateExperienceAjax(Experience model)
        {
            if (ModelState.IsValid)
            {
                var experience = context.Experience.FirstOrDefault(e => e.ExperienceID == model.ExperienceID);
                if (experience != null)
                {
                    experience.Head = model.Head;
                    experience.Title = model.Title;
                    experience.Date = model.Date;
                    experience.Description = model.Description;

                    context.SaveChanges();

                    return Json(new { success = true, message = "Experience updated successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Experience not found!" });
                }
            }
            return Json(new { success = false, message = "Invalid data!" });
        }

    }
}
