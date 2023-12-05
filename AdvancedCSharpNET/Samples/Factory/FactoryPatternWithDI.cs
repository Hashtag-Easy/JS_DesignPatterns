using DesignPatterns.Samples.SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace DesignPatterns.Samples.WithDI
{

    public class CarFactoryPatternWithDI : ICarFactoryPatternWithDI
    {
        private readonly IEngine engine;
        private readonly IPaintProvider paint;

        private readonly int year = DateTime.Now.Year;
        private const string Manufacturer = "SomeCompany";

        public CarFactoryPatternWithDI(IEngine engine, IPaintProvider paint)
        {
            this.engine = engine;
            this.paint = paint;
        }

        public ICar CreateCar()
        {
            return new Car(Manufacturer, year, engine, paint);
        }
    }

    public class Car : ICar
    {
        private readonly IEngine engine;
        private readonly IPaintProvider paint;

        public string Manufacturer { get; private set; }
        public int ProductionYear { get; private set; }

        public Car(string manufacturer, int productionYear, IEngine engine,
            IPaintProvider paint)
        {
            Manufacturer = manufacturer;
            ProductionYear = productionYear;
            this.engine = engine;
            this.paint = paint;
        }
    }


    public class Program
    {
        public static void Main(string[] args) 
        {

            var unity = new UnityContainer();

            unity.RegisterSingleton<ICarFactoryPatternWithDI, CarFactoryPatternWithDI>();
            unity.RegisterType<IEngine, SportEngine>("Sport");
            unity.RegisterType<IEngine, SportEngine>("SportWithHP", new InjectionConstructor(550));
            unity.RegisterType<IEngine, StandardEngine>("Standard");
            unity.RegisterType<IPaintProvider, MattPaint>();
            unity.RegisterType<ILogger, DbLogger>();

            var myEngine = unity.Resolve<IEngine>("Sport");




            var myCar = unity.Resolve<ICarFactoryPatternWithDI>().CreateCar();
        }

        class MyClass
        {
            private readonly ICarFactoryPatternWithDI carFactory;

            public MyClass(ICarFactoryPatternWithDI carFactory)
            {
                this.carFactory = carFactory;
            }


        }
    }
}
