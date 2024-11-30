using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult SkillList()
        {
            var value = context.Skill.ToList();
            return View(value);
        }


        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();

            return RedirectToAction("SkillList");

        }

        public IActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();

            return RedirectToAction("SkillList");
        }


        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = context.Skill.Find(id); 
            if (skill == null)
            {
                return NotFound(); 
            }
            return View(skill); 
        }

        [HttpPost]
        public JsonResult UpdateSkill(Skill model)
        {
            if (ModelState.IsValid)
            {
                var skill = context.Skill.FirstOrDefault(s => s.SkillID == model.SkillID); 
                if (skill != null)
                {
                    skill.Title = model.Title;
                    skill.Value = model.Value;
                    context.SaveChanges();

                    return Json(new { success = true, message = "Skill updated successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Skill not found!" });
                }
            }
            return Json(new { success = false, message = "Invalid data!" });
        }



    }
}
