using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class BlogController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = context.Blog.FirstOrDefault(b => b.BlogID == id);
            if (blog == null)
            {
                blog = new Blog
                {
                    Title = "Default Title",
                    SubDescription = "Default SubDescription",
                    Details = "Default Details"
                };
                context.Blog.Add(blog);
                context.SaveChanges();
            }

            return View(blog);
        }



        [HttpPost]
        public JsonResult UpdateBlogAjax([FromBody] Blog blog)
        {
            var existingBlog = context.Blog.FirstOrDefault();

            if (existingBlog != null)
            {
                existingBlog.Title = blog.Title;
                existingBlog.SubDescription = blog.SubDescription;
                existingBlog.Details = blog.Details;

                context.SaveChanges();

                return Json(new { success = true, message = "Data updated successfully!" });
            }

            return Json(new { success = false, message = "Update failed! Record not found." });
        }

    }
}







