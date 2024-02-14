using Microsoft.AspNetCore.Mvc;

namespace MVC_Features.Controllers
{
    public class StateMangmentController : Controller
    {
        // set temp Data
        // StateMangment/SetTempData
        public IActionResult SetTempData()
        {
            string name = "Ali";
            int id = 10;

            TempData["username"] = name;
            TempData["id"] = id;
            return Content("Set temp ");
        }

        public IActionResult GetTempData()
        {
            //string name = TempData["username"].ToString();
            //int id = (int)TempData["id"];
            //return Content($"name : {name}, id: {id}");
            return Content($"name : {TempData["username"]}, id: {TempData["id"]}");
        }

        public IActionResult ExtendTempData()
        {
            TempData.Keep("username");
            return Content($"name : {TempData["username"]}, id: {TempData["id"]}");

        }



        public IActionResult SetCookies() {
            // session Cookies
            HttpContext.Response.Cookies.Append("name", "ali");
            HttpContext.Response.Cookies.Append("id", "12");


            // presisntent cookies
            //CookieOptions options = new()
            //{
            //    Expires = DateTime.Now.AddMinutes(30),
            //};
            //HttpContext.Response.Cookies.Append("name", "ali",options);
            //HttpContext.Response.Cookies.Append("id", "12",options);
            return Content($"Set data in cookies");
        }




        public IActionResult GetCookies()
        {
            string name = HttpContext.Request.Cookies["name"];
            int id = int.Parse(HttpContext.Request.Cookies["id"]);

            return Content($"name : {name}, id: {id}");


        }


        public IActionResult RemoveCookies()
        {
            HttpContext.Response.Cookies.Delete("name");
            return Content("Data Removed");
        }

        public IActionResult SetSessionData()
        {
            HttpContext.Session.SetString("name", "ali");
            HttpContext.Session.SetInt32("age", 12);

            return Content("Save Data");
        }


        public IActionResult GetSessionData()
        {
           string? name = HttpContext.Session.GetString("name");
           int? age = HttpContext.Session.GetInt32("age");

            return Content($"name : {name}, id: {age}");

        }

        public IActionResult ClearSession()
        {
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("name");

            return Content("Data Cleared");
        }
    }
}
