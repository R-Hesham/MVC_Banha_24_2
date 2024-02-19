using Microsoft.AspNetCore.Mvc;

namespace MVC_Features.Controllers
{
    //[Route("/test")]
    public class RoutingController : Controller
    {
        // /Routing/Index
        public IActionResult Index()
        {
            return Content("index");
        }

        // /Routing/data/4
        // /Routing/data?id=4
        public IActionResult data(int id)
        {
            return Content($"index {id}");
        }

        // default routing
        // /Routing/test?mngId=5


        // /r/test
        //[Route("/testfunction/{id:int}")]
        public IActionResult test(int name, int mngId)
        {

            return Content($"index {mngId}, {name}");
        }
    }
}
