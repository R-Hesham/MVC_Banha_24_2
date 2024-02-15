using Microsoft.AspNetCore.Mvc;
using MVC_Features.Models;

namespace MVC_Features.Controllers
{
    public class HelpersController : Controller
    {
        BanhaITIContext context = new BanhaITIContext();
        public IActionResult HTMLHelper()
        {
            return View();
        }

        //Instructor
        public IActionResult Add()
        {
            ViewBag.departments = context.Departments.ToList();
            return View();
        }
        public IActionResult AddDB(Instructor instructor)
        {
            if (instructor.Name != null)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();

                return RedirectToAction("Index", "Instructor");

            }
            else
            {
                ViewBag.departments = context.Departments.ToList();
                return View("Add");
            }
        }

        // Edit 
        public IActionResult Edit(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i => i.Id == id);
            ViewBag.departments = context.Departments.ToList();
            return View(instructor);
        }
        public IActionResult EditDB(Instructor instructor)
        {
            // Server side validation
            if (instructor.Name != null)
            {
                context.Instructors.Update(instructor);
                context.SaveChanges();

                return RedirectToAction("Index", "Instructor");
            }
            else
            {
                ViewBag.departments = context.Departments.ToList();
                return View("Edit");
            }

        }
    }
}
