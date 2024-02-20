using Microsoft.AspNetCore.Mvc;
using MVC_Features.Lifetime;

namespace MVC_Features.Controllers
{
    public class LifeTimeController(ImyService service) : Controller
    {
        //private readonly ImyService service;

        //public LifeTimeController(ImyService service)
        //{
        //    this.service = service;
        //}
        public IActionResult Index()
        {
            ViewBag.id =  service.id.ToString();
            return View();
        }
    }
}
