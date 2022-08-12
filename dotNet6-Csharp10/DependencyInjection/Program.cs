// global usings in using.cs

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // main Fucking Point
            var manager = new Manager(new Repository()); // <-- Dependency injection
            Console.WriteLine(manager.Load());

            Console.WriteLine(new Manager(new BlaBla()).Load()); // <-- Dependency injection
            Console.ReadLine();
        }
    }

    interface IRepository
    {
        string Load();
    }    
    
    class Manager
    {
        private readonly IRepository _repository;

        public Manager(IRepository repository)
        {
            _repository = repository;
        }

        public string Load()
        {
            var input = _repository.Load();           
            return input.ToUpper();
        }
    }


    class BlaBla : IRepository
    {
        // without constructor
        public string Load()
        {
            return "BlaBla";
        }
    }

    class Repository:IRepository
    {
        public Repository()
        {

        }

        public string Load()
        {
            return "berni";
        }
    }
}
