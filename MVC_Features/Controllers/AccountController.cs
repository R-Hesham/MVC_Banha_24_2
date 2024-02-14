using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MVC_Features.Models;

namespace MVC_Features.Controllers
{
    public class AccountController : Controller
    {
        BanhaITIContext context = new();
        // display form
        public IActionResult Login()
        {
            return View();
        }

        // get data (set State)
        public IActionResult LoginDB(string name, string  password)
        {
            // check DB
            Instructor instructor = context.Instructors.SingleOrDefault(i=>i.Name == name && i.Id==int.Parse(password));

            if (instructor != null)
            {
                // Set session Data
                    HttpContext.Session.SetString("name",instructor.Name);
                    HttpContext.Session.SetInt32("id",instructor.Id);

                // return
                return RedirectToAction("Index", "Instructor");
            }
            return View("Login");
        }
    }
}
