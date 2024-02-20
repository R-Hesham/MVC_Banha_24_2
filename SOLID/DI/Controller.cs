using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DI
{
    internal class Controller
    {
        //private Irepo _repo = new Repo();
        private Irepo _repo;


        // Constructor injection
        //public Controller(Irepo repo)
        //{
        //    _repo = repo;
        //}

        // property injection
        public Irepo Repo {
            //get { return _repo; },
            set { _repo = value; }
        }

        // Method injection
        public void SetRepo(Irepo repo)
        {
            _repo = repo;
        }

        public void UseRepo()
        {
            
            Console.WriteLine(_repo);
        }
    }
}
