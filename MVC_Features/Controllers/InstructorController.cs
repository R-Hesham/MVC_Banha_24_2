using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Features.Models;

namespace MVC_Features.Controllers
{
    public class InstructorController : Controller
    {
        BanhaITIContext context;
        public InstructorController()
        {
            context = new BanhaITIContext();
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.Include(i=>i.workDepartment).ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor ins = context.Instructors.Include(i => i.workDepartment).SingleOrDefault(i=>i.Id == id);
            return View(ins);
        }
        public IActionResult GetCard(int id)
        {
            Instructor ins = context.Instructors.Include(i => i.workDepartment).SingleOrDefault(i => i.Id == id);
            return PartialView("_InstructorCardPartial",ins);
        }
        public IActionResult GetData(int id)
        {
            Instructor ins = context.Instructors.Include(i => i.workDepartment).SingleOrDefault(i => i.Id == id);
            var data = new { ins.Name, ins.Degree };
            return Json(data);
        }

        // Create 
        // display form
        public IActionResult GetAddForm()
        {
            List<Department> departments = context.Departments.ToList();

            ViewData["departments"] = departments;
            return View();
        }

        // get form data
        public IActionResult GetFormData(string name, string degree, decimal salary, int deptId)
        {
            Instructor instructor = new()
            {
                Name = name,
                Degree = degree,
                Salary = salary,
                Dept_Id = deptId
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Update
        // display form
        public IActionResult GetEditForm(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i => i.Id == id);
            List<Department> departments = context.Departments.ToList();

            ViewData["departments"] = departments;
            return View(instructor);
        }
        public IActionResult Update(int id, string name, string degree, decimal salary, int deptId) {

            Instructor instructor = context.Instructors.SingleOrDefault(i => i.Id == id);
            instructor.Name = name;
            instructor.Degree = degree;
            instructor.Salary = salary;
            instructor.Dept_Id = deptId;

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        // Delete 
        //ffff

        public IActionResult Delete(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i => i.Id == id);
            context.Instructors.Remove(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
