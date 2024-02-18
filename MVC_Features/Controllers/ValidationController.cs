using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Features.Models;
using MVC_Features.ViewModels;

namespace MVC_Features.Controllers
{
    public class ValidationController : Controller
    {
        BanhaITIContext context = new BanhaITIContext();
        // student
        public IActionResult Index()
        {
            List<Student> students = context.Students.ToList();   
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.departments = new SelectList(context.Departments, nameof(Department.Id), nameof(Department.Name));

            StudentVM studentVM = new StudentVM()
            {
                departments = new SelectList(context.Departments, nameof(Department.Id), nameof(Department.Name))
            };
            return View(studentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // piprline => middlewres
        // ModelBinder  =>  data type validation
        // ModelValidator => check data annotations
        public IActionResult Add(StudentVM std)
        {if(std.Address == "Cairo" && std.Age != 23)
            {
                ModelState.AddModelError("", "Student lives in cairo must be 23 years old");
            }
            if(ModelState.IsValid) {
                Student student = new Student()
                {
                    Id = std.Id,
                    Name = std.Name,
                    Address = std.Address,
                    Age = std.Age,
                    DeptId = std.DeptId,
                };
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewBag.departments = new SelectList(context.Departments, nameof(Department.Id), nameof(Department.Name));
            List<Department> departments = context.Departments.ToList();
            std.departments = new SelectList(departments, nameof(Department.Id), nameof(Department.Name));
            return View(std);
        }
    }
}
