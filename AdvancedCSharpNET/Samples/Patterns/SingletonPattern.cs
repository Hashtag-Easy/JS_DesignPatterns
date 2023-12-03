
namespace DesignPatterns.Samples.Patterns
{
    internal class SingletonPattern
    {

        private static SingletonPattern instance;

        private SingletonPattern() { }


        public static SingletonPattern Instance { 
            get 
            { 
                if (instance == null)
                    instance = new SingletonPattern();
                
                return instance; 
            } 
        }
    }
}
