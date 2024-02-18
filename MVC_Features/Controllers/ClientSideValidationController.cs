using Microsoft.AspNetCore.Mvc;

namespace MVC_Features.Controllers
{
    public class ClientSideValidationController : Controller
    {
        public IActionResult NameLength(string name,string address, int age)
        {
            if(name.Length < 4 || name.Length > 50)
                return Json(false);
            else
                return Json(true);
        }
    }
}
