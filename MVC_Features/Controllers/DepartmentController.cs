using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC_Features.Controllers
{
    public class DepartmentController : Controller
    {
        BanhaITIContext context = new();
        public IActionResult Index()
        {
            List<Department> list = context.Departments.ToList();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            Department department = context.Departments.Include(d=>d.manger).Include(d=>d.instructors).SingleOrDefault(d=>d.Id == id);
            ViewBag.extra = "gggggggg";
            return View(department);
        }
    }
}
