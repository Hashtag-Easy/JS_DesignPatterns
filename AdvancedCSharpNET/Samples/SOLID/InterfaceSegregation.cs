using System;

namespace DesignPatterns.Samples.SOLID
{
    internal interface IMultiFunctionalPriner : IPrinter, IScanner
    {
    }


    public class MultiFunctionalPrinter : IMultiFunctionalPriner
    {
        public void Print(byte[] page)
        {
            Console.WriteLine("Print page");
        }

        public void Scan()
        {
            Console.WriteLine("Scan document page");
        }
    }


    public class JustALaserPrinter : IPrinter
    {
        public void Print(byte[] stream)
        {
            Console.WriteLine("Laser printing a page");
        }
    }



    internal interface IPrinter
    {
        void Print(byte[] stream);
    }
    internal interface IScanner
    {
        void Scan();
    }

}