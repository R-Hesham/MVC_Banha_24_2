using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Features.Models;
using MVC_Features.Repositories;

namespace MVC_Features.Controllers
{
    public class InstructorController : Controller
    {
        private IInstructorRepo instructorRepo;
        private IDepartmentRepo departmentRepo;
        //1- ask to inject
        public InstructorController(IInstructorRepo _insRepo, IDepartmentRepo _deptRepo)
        {
            instructorRepo = _insRepo;
            departmentRepo = _deptRepo;
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = instructorRepo.GetAll();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor ins = instructorRepo.GetById(id);
            return View(ins);
        }
        public IActionResult GetCard(int id)
        {
            Instructor ins = instructorRepo.GetById(id);
           return PartialView("_InstructorCardPartial",ins);
        }
        public IActionResult GetData(int id)
        {
            Instructor ins = instructorRepo.GetById(id);
            var data = new { ins.Name, ins.Degree };
            return Json(data);
        }

        // Create 
        // display form
        public IActionResult GetAddForm()
        {
            List<Department> departments = departmentRepo.GetAll();

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

            instructorRepo.Add(instructor);

            return RedirectToAction("Index");
        }

        // Update
        // display form
        public IActionResult GetEditForm(int id)
        {
            Instructor instructor = instructorRepo.GetById(id);
            List<Department> departments = departmentRepo.GetAll();

            ViewData["departments"] = departments;
            return View(instructor);
        }

        public IActionResult Update(Instructor ins) {

           instructorRepo.Update(ins);

            return RedirectToAction("Index");
        }


        // Delete 
        //ffff

        public IActionResult Delete(int id)
        {
            instructorRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
