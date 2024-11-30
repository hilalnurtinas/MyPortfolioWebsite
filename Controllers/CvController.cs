using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class CvController : Controller
    {

        MyPortfolioContext context = new MyPortfolioContext();


        [HttpGet]
        public IActionResult UpdateCvLink()
        {
            var cv = context.Cv.FirstOrDefault();

            if (cv == null)
            {
                cv = new Cv
                {
                    CvLink = "Default CvLink",

                };
                context.Cv.Add(cv);
                context.SaveChanges();
            }

            return View(cv);
        }



        [HttpPost]
        public JsonResult UpdateCvAjax([FromBody] Cv cv)
        {
            var existingCv = context.Cv.FirstOrDefault();

            if (existingCv != null)
            {
                existingCv.CvLink = cv.CvLink;

                context.SaveChanges();

                return Json(new { success = true, message = "Data updated successfully!" });
            }

            return Json(new { success = false, message = "Update failed! Record not found." });
        }

    }

}


