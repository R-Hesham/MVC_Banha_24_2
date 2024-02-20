namespace MVC_Features.Repositories
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public int Add(Department department);
        public int Update(Department department);
        public int Delete(int id);
    }
}
