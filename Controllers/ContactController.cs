using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebsite.DAL.Context;
using MyPortfolioWebsite.DAL.Entities;

namespace MyPortfolioWebsite.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        [HttpGet]
        public IActionResult UpdateContact()
        {

            var contact = context.Contact.FirstOrDefault();
            if (contact == null)
            {
                contact = new Contact
                {
                    Title = "Default Title",
                    Description = "Default Description",
                    Phone1 = "Default Phone",
                    Phone2 = "Default Phone",
                    Email1 = "someone@example.com",
                    Email2 = "someone@example.com",
                    Address = "Default Address"
                };
                context.Contact.Add(contact);
                context.SaveChanges();
            }

            return View(contact);
        }


        [HttpPost]
        public IActionResult UpdateContactAjax([FromBody] Contact updatedContact)
        {
            if (updatedContact == null)
            {
                return Json(new { success = false, message = "Invalid data provided." });
            }

            try
            {
                var contact = context.Contact.FirstOrDefault();
                if (contact == null)
                {
                    return Json(new { success = false, message = "Contact not found." });
                }

                contact.Title = updatedContact.Title;
                contact.Description = updatedContact.Description;
                contact.Phone1 = updatedContact.Phone1;
                contact.Phone2 = updatedContact.Phone2;
                contact.Email1 = updatedContact.Email1;
                contact.Email2 = updatedContact.Email2;
                contact.Address = updatedContact.Address;

                context.SaveChanges();

                return Json(new { success = true, message = "Contact updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

    }
}
