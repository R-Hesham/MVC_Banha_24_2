using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_Features.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Remote("NameLength","ClientSideValidation", AdditionalFields = nameof(Address) + "," + nameof(Age), ErrorMessage = "name must be 4 up to 50 character")]
        [Length(4,50,ErrorMessage ="name must be 4 up to 50 character")]
        [UniqueName]
        public string Name { get; set; }
        [RegularExpression("^(Alex|Cairo|Giza)$")]
        [Required(ErrorMessage = "*")]
        public string? Address { get; set; }
        [Range(15,30,ErrorMessage ="age must be from 15 to 30")]
        [Required(ErrorMessage = "*")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "*")]
        public int? DeptId { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Compare("ConfirmPassword", ErrorMessage = "Password must match confirm")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password must match confirm")]
        public string ConfirmPassword { get; set; }
        [ValidateNever]
        public SelectList  departments { get; set; }
        //public int hhhh { get; set; }
        //public Student  MyProperty { get; set; }
    }
}
