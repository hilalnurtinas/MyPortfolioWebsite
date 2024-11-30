using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class BlogPostController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult BlogPostList()
        {
            var value = context.BlogPost.ToList();
            return View(value);
        }


        [HttpGet]
        public IActionResult CreateBlogPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlogPost(BlogPost blogPost)
        {
            context.BlogPost.Add(blogPost);
            context.SaveChanges();

            return RedirectToAction("BlogPostList");

        }

        public IActionResult DeleteBlogPost(int id)
        {
            var value = context.BlogPost.Find(id);
            context.BlogPost.Remove(value);
            context.SaveChanges();

            return RedirectToAction("BlogPostList");
        }

        [HttpGet]
        public IActionResult UpdateBlogPost(int id)
        {
            var BlogPost = context.BlogPost.FirstOrDefault(e => e.BlogPostID == id);

            return View(BlogPost);
        }


        [HttpPost]
        public JsonResult UpdateBlogPostAjax(BlogPost model)
        {
            if (ModelState.IsValid)
            {
                var blogPost = context.BlogPost.FirstOrDefault(e => e.BlogPostID == model.BlogPostID);
                if (blogPost != null)
                {
                    blogPost.Head = model.Head;
                    blogPost.Date = model.Date;
                    blogPost.Description = model.Description;
                    blogPost.Url = model.Url;
                    blogPost.UrlTitle = model.UrlTitle;

                    context.SaveChanges();

                    return Json(new { success = true, message = "BlogPost updated successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "BlogPost not found!" });
                }
            }
            return Json(new { success = false, message = "Invalid data!" });
        }

    }
}



