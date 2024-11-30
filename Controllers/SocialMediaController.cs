using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {

            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult DeleteSocialMedia(int id)
        {

            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = context.SocialMedia.Find(id);

            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        [HttpPost]
        public JsonResult UpdateSocialMedia(SocialMedia model)
        {
            if (ModelState.IsValid)
            {
                var socialMedia = context.SocialMedia.FirstOrDefault(sm => sm.SocialMediaID == model.SocialMediaID);

                if (socialMedia != null)
                {
                    socialMedia.Title = model.Title;
                    socialMedia.Url = model.Url;
                    socialMedia.Icon = model.Icon;

                    context.SaveChanges();

                    return Json(new { success = true, message = "Social Media updated successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Social Media not found!" });
                }
            }

            return Json(new { success = false, message = "Invalid data!" });
        }

    }
}
