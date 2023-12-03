using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples.Patterns
{
    internal interface ICloneable<T>
    {
        T DeepCopy();
    }

    internal abstract class Shape : ICloneable<Shape>
    {
        public abstract Shape DeepCopy();
    }

    internal class Rect : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override Shape DeepCopy()
        {
            return new Rect() { X = X, Y = Y };
        }
    }
}
