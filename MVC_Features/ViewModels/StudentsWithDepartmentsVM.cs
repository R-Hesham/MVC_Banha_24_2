using MVC_Features.Models;

namespace MVC_Features.ViewModels
{
    /*
     ViewModel => userDefined Class 
        View Business Logic
        

    Data => ViewModel 
    Cases to create viewModel

    - Merge two models
    - Model with extra data 
    - Some Data in model
    - Security => validate model
        hiding main table structure
     */



    public class StudentsWithDepartmentsVM
    {
        public List<Student>  Students { get; set; }
        public List<Department> Departments { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
