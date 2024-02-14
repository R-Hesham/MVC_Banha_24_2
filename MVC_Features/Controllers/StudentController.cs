using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Features.Models;
using MVC_Features.ViewModels;

namespace MVC_Features.Controllers
{
    public class StudentController : Controller
    {
        

        private BanhaITIContext context;
        public StudentController()
        {
            context = new BanhaITIContext();
        }
        // get all
        // Student/Index
        public IActionResult Index()
        {
            List<Student> students = context.Students.ToList();
            // transfer data from action to view

            // transfer extra data

            List<Department> departments = context.Departments.ToList();

            string name = "Username";
            int id = 100;

            //ViewData["name"] = name;
            ////ViewData["id"] = id;
            ////ViewData["departments"] = departments;

            //ViewBag.id = id;
            ////ViewBag.name = name;
            //ViewBag.departments = departments;

            // View Model
            StudentsWithDepartmentsVM stdDept = new();  // Target Type
            stdDept.Name = name;
            stdDept.Id = id;
            stdDept.Departments = departments;
            stdDept.Students = students;

            List<Instructor> mangers = context.Departments.Include(d=>d.manger).Select(d => d.manger).ToList();
            List<Instructor> instructors = context.Instructors.Except<Instructor>(mangers).Distinct().ToList();
            return View(stdDept);
        }

        // get by id
        // Student/Details?id=2
        public IActionResult Details(int id)
        {
            Student student = context.Students.SingleOrDefault(s => s.Id == id);
            return View(student);
        }
    }
}
