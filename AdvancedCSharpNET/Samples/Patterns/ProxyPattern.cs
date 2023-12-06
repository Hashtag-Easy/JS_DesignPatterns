using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples.Patterns.Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car being driven");
        }
    }

    public class CarProxy : ICar
    {
        private Car car = new Car();
        private Driver driver;

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 18)
                car.Drive();
            else
            {
                Console.WriteLine("Driver too young");
            }
        }
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }


    public class LazyProxyCar : ICar
    {
        private Lazy<Car> lazyCar;

        public void Drive()
        {
            var car = lazyCar.Value;

            car.Drive();
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(12)); // 22
            car.Drive();
        }
    }
}
