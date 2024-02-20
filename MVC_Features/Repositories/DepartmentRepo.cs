using Microsoft.EntityFrameworkCore;

namespace MVC_Features.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        BanhaITIContext context;
        public DepartmentRepo(BanhaITIContext _Context)
        {
            context = _Context;
        }
        // CRUD

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.SingleOrDefault(i => i.Id == id);
        }

        public int Add(Department dept)
        {
            context.Departments.Add(dept);
            return context.SaveChanges();
        }

        public int Update(Department dept)
        {
            context.Departments.Update(dept);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.Departments.Remove(GetById(id));
            return context.SaveChanges();
        }
    }
}
