using Microsoft.AspNetCore.Mvc;
using MVC_Features.Models;
using System.Text.Json;

namespace MVC_Features.Controllers
{
    public class ModelBinderController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        // Model Binder 
        // Bind Request data to Action Parameters

        // To Set values
        // 1- Form Data
        // 2- RoteValues
        // 3- QueryString
        // 4- default

        // 1- primitive Data Types
        //http://localhost:5101/ModelBinder/GetData?name=ddd&age=3
        //public IActionResult GetData(string name, int age, int id)

        // 2- collections
        // 2-1 list,array
        // http://localhost:5101/ModelBinder/GetData/3?data=str&data=uuu
        //public IActionResult GetData(List<string> Data)
        // 2-2 Dictionary
        //http://localhost:5101/ModelBinder/GetData/3?data%5B1%5D=ee&data%5B2%5D=pp&data%5B0%5D=mm&data%5Bname%5D=ali&data%5Bage%5D=5&data%5Baddress%5D=cairo
        //http://localhost:5101/ModelBinder/GetData/3?data[1]=ee&data[2]=pp&data[0]=mm&data[name]=ali&data[age]=5&data[address]=cairo
        //public IActionResult GetData(Dictionary<string,string> Data)

        //3- User Defined Data Type
        //http://localhost:5101/ModelBinder/GetData/3?name=ali&salary=5000
        //public IActionResult GetData(Instructor Data)

        // 4- inner object
        //http://localhost:5101/ModelBinder/GetData/3?name=ali&salary=5000&workDepartment.name=sd
        public IActionResult GetData(Instructor Data,[Bind(Prefix = "workDepartment")]Department dept)
        {
            string data = JsonSerializer.Serialize(Data);
            return Content(data);
        }
    }
}
