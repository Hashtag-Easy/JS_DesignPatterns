using System;

namespace DesignPatterns.Samples.SOLID
{
    internal interface IMultiFunctionalPriner
    {
        void Print(byte[] stream);
        void Scan();
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


    public class JustALaserPrinter : IMultiFunctionalPriner
    {
        public void Print(byte[] stream)
        {
            Console.WriteLine("Laser printing a page");
        }

        public void Scan()
        {
            //Do not use this method
            throw new NotImplementedException();
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