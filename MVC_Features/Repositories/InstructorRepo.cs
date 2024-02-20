using Microsoft.EntityFrameworkCore;

namespace MVC_Features.Repositories
{
    public class InstructorRepo : IInstructorRepo
    {
        BanhaITIContext context;
        public InstructorRepo(BanhaITIContext _Context)
        {
            context = _Context;
        }
        // CRUD

        public List<Instructor> GetAll()
        {
            return context.Instructors.Include(i => i.workDepartment).ToList();
        }

        public Instructor GetById(int id)
        {
            return context.Instructors.Include(i => i.workDepartment).SingleOrDefault(i => i.Id == id);
        }

        public int Add(Instructor ins)
        {
            context.Instructors.Add(ins);
            return context.SaveChanges();
        }

        public int Update(Instructor ins)
        {
            context.Instructors.Update(ins);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.Instructors.Remove(GetById(id));
            return context.SaveChanges();
        }
    }
}
