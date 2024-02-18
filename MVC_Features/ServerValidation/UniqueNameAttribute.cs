using System.ComponentModel.DataAnnotations;

namespace MVC_Features.ServerValidation
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        //public override bool IsValid(object? value)
        //{
        //    BanhaITIContext context = new();

        //    var result = context.Students.Where(s => s.Name == value.ToString()).ToList();
        //    if(result.Count > 0) {
        //        return false;
        //    }
        //    return true;
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            StudentVM std = (StudentVM)validationContext.ObjectInstance;
            BanhaITIContext context = new();

            var result = context.Students.Where(s => s.Name == value.ToString()).ToList();
            if (result.Count > 0)
            {
                return new ValidationResult("Not unique");
            }
            return ValidationResult.Success;
        }
    }
}
