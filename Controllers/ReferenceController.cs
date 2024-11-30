using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class ReferenceController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult ReferenceList()
        {
            var value = context.Reference.ToList();
            return View(value);
        }


        [HttpGet]
        public IActionResult CreateReference()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReference(Reference reference)
        {
            context.Reference.Add(reference);
            context.SaveChanges();

            return RedirectToAction("ReferenceList");

        }

        public IActionResult DeleteReference(int id)
        {
            var value = context.Reference.Find(id);
            context.Reference.Remove(value);
            context.SaveChanges();

            return RedirectToAction("ReferenceList");
        }

        [HttpGet]
        public IActionResult UpdateReference(int id)
        {
            var Reference = context.Reference.FirstOrDefault(e => e.ReferenceID == id);

            return View(Reference);
        }


        [HttpPost]
        public JsonResult UpdateReferenceAjax(Reference model)
        {
            if (ModelState.IsValid)
            {
                var reference = context.Reference.FirstOrDefault(e => e.ReferenceID == model.ReferenceID);
                if (reference != null)
                {
                    reference.ReferenceName = model.ReferenceName;
                    reference.Title = model.Title;
                    reference.Description = model.Description;
                    reference.ImageUrl = model.ImageUrl;

                    context.SaveChanges();

                    return Json(new { success = true, message = "Reference updated successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Reference not found!" });
                }
            }
            return Json(new { success = false, message = "Invalid data!" });
        }

    }
}


