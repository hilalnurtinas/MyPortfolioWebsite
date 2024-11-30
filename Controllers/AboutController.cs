using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();


        [HttpGet]
        public IActionResult UpdateAbout()
        {
            var about = context.About.FirstOrDefault();

            if (about == null)
            {
                about = new About
                {
                    Title = "Default Title",
                    SubDescription = "Default SubDescription",
                    Details = "Default Details"
                };
                context.About.Add(about);
                context.SaveChanges();
            }

            return View(about);
        }

        //// POST: Update About (Form gönderimi)
        //[HttpPost]
        //public IActionResult UpdateAbout(About about)
        //{
        //    var existingAbout = context.About.FirstOrDefault();

        //    if (existingAbout != null)
        //    {
        //        existingAbout.Title = about.Title;
        //        existingAbout.SubDescription = about.SubDescription;
        //        existingAbout.Details = about.Details;

        //        context.SaveChanges();
        //        TempData["SuccessMessage"] = "Data updated successfully!";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Update failed! Record not found.";
        //    }

        //    return RedirectToAction("UpdateAbout");
        //}


        [HttpPost]
        public JsonResult UpdateAboutAjax([FromBody] About about)
        {
            var existingAbout = context.About.FirstOrDefault();

            if (existingAbout != null)
            {
                existingAbout.Title = about.Title;
                existingAbout.SubDescription = about.SubDescription;
                existingAbout.Details = about.Details;

                context.SaveChanges();

                return Json(new { success = true, message = "Data updated successfully!" });
            }

            return Json(new { success = false, message = "Update failed! Record not found." });
        }

    }
}

