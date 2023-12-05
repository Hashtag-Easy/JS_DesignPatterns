using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Exercises
{

    public interface IValueContainer
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        //public static int Sum(this List<IValueContainer> containers)
        //{
        //    int result = 0;
        //    foreach (var container in containers)
        //    {
        //        foreach (var i in container)
        //            result += i;
        //    }
        //    return result;
        //}
    }
}
