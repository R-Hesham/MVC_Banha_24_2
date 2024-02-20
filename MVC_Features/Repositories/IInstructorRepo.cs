
namespace MVC_Features.Repositories
{
    public interface IInstructorRepo
    {
        int Add(Instructor ins);
        int Delete(int id);
        List<Instructor> GetAll();
        Instructor GetById(int id);
        int Update(Instructor ins);
    }
}