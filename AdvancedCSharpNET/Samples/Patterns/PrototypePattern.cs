using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples.Patterns
{

    internal interface ICloneable<T>
    {
        T DeepCopy();
    }

    public class Border : ICloneable<Border>
    {
        public int Weight { get; set; }
        public string Style { get; set; }

        public Border DeepCopy()
        {
            return new Border() {Weight = this.Weight, Style = this.Style };
        }
    }

    internal abstract class Shape : ICloneable<Shape>
    {
        public Color Color { get; set; }
        public Border Border { get; set; }
        protected string _name = "";

        protected Shape(string name)
        {
            _name = name;
        }

        public abstract Shape DeepCopy();
    }

    internal class Rect : Shape
    {
        public Rect(Rect rect) : this("")
        {
            StartX = rect.StartX; StartY = rect.StartY;
            EndX = rect.EndX; EndY = rect.EndY;

            Color = rect.Color;
            Border = new Border() { Style = rect.Border.Style, Weight = rect.Border.Weight };
        }

        public Rect() : this("")
        {
            Border = new Border();
        }

        protected Rect(string name) : base(name) { }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public override Shape DeepCopy()
        {
            return new Rect(_name)
            {
                StartX = StartX + 20,
                StartY = StartY + 20,
                EndX = EndX + 20,
                EndY = EndY + 20,
                Color = Color,
                Border = Border.DeepCopy()
            };
        }
    }


    class TestPrototype
    {
        public void Test()
        {
            var rect = new Rect() { StartX = 4, StartY = 5 };

            var rect2 = new Rect(rect);
            //var rect2 = rect.DeepClone();
        }
    }
}
