using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class FeatureController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();


        [HttpGet]
        public IActionResult UpdateFeature()
        {
            var feature = context.Feature.FirstOrDefault();

            if (feature == null)
            {
                feature = new Feature
                {
                    Title = "Default Title",
                    Description = "Default Description"
                };
                context.Feature.Add(feature);
                context.SaveChanges();
            }

            return View(feature);
        }

        [HttpPost]
        public JsonResult UpdateFeatureAjax([FromBody] Feature feature)
        {
            var existingFeature = context.Feature.FirstOrDefault();

            if (existingFeature != null)
            {
                existingFeature.Title = feature.Title;
                existingFeature.Description = feature.Description;

                context.SaveChanges();

                return Json(new { success = true, message = "Data updated successfully!" });
            }

            return Json(new { success = false, message = "Update failed! Record not found." });
        }
    }
}
