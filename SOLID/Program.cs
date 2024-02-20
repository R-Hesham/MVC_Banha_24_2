using SOLID.DI;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestFly(new Eagle());
            //TestFly(new Benguin());


            // Test DI

            
            Repo repo = new Repo();


            // Constructor injection
            //Controller controller = new Controller(repo);


            // property injection
            //Controller controller = new Controller();
            // use object until need dependency
            /*controller.Repo = repo*/;

            // Method injection
            Controller controller = new Controller();
            // use object until need dependency
            controller.SetRepo(repo);
        }

        static void TestBird(Bird bird)
        {
            
        }

        static void TestFly(IFly fly)
        {

        }
    }
}
