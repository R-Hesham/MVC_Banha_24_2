namespace MVC_Features.Lifetime
{
    public class myService : ImyService
    {
        public Guid id { get; set; }

        public myService()
        {
            id = Guid.NewGuid();
        }

    }
}
