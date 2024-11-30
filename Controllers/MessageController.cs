using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var values = context.Message.ToList();
            return View(values);
        }

        public IActionResult ChangeIsReadTrue(int id)
        {
            var value = context.Message.Find(id);
            value.IsRead = true;
            context.SaveChanges();

            return RedirectToAction("Inbox");
        }

        public IActionResult ChangeIsReadFalse(int id)
        {
            var value = context.Message.Find(id);
            value.IsRead = false;
            context.SaveChanges();

            return RedirectToAction("Inbox");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = context.Message.Find(id);
            context.Message.Remove(value);
            context.SaveChanges();

            return RedirectToAction("Inbox");
        }

        public IActionResult MessageDetail(int id)
        {
            var value = context.Message.Find(id);
            return View(value);
        }

        public IActionResult GetUnreadMessageCount()
        {
            var unreadCount = context.Message.Count(m => !m.IsRead);
            return Json(new { count = unreadCount });
        }

        [HttpPost]
        public JsonResult SendMessage([FromForm] Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                context.Message.Add(message);
                context.SaveChanges();

                return Json(new { success = true, message = "Your message was sent, thank you!" });
            }

            return Json(new { success = false, message = "Something went wrong. Please try again." });
        }
    }
}
