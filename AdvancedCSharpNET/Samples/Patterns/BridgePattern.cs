using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples.Patterns.Bridge.Problem
{

    #region problem
    public abstract class Shape
    {
        public string Name { get; set; }
    }

    public class Triangle : Shape
    {
        public Triangle() => Name = "Triangle";
    }

    public class Square : Shape
    {
        public Square() => Name = "Square";
    }

    public class VectorSquare : Square
    {
        public override string ToString() => $"Drawing {Name} as lines";
    }

    public class RasterSquare : Square
    {
        public override string ToString() => $"Drawing {Name} as pixels";
    }

    public class VectorTriangle : Triangle
    {
        public override string ToString() => $"Drawing {Name} as lines";
    }

    public class RasterTriangle : Triangle
    {
        public override string ToString() => $"Drawing {Name} as pixels";
    }

    #endregion
}

namespace DesignPatterns.Samples.Patterns.Bridge.Solution
{
    #region solution

    public abstract class Shape
    {
        private readonly GraphicStyle graphicStyle;

        public Shape(GraphicStyle graphicStyle)
        {
            this.graphicStyle = graphicStyle;
        }
        public string Name { get; set; }

        public override string ToString() => $"Drawing {Name} as {graphicStyle.GetDrawing()}";
    }

    public class Triangle : Shape
    {
        public Triangle(GraphicStyle graphicStyle) : base(graphicStyle)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(GraphicStyle graphicStyle) : base(graphicStyle)
        {
            Name = "Square";
        }
    }

    public abstract class GraphicStyle
    {
        public abstract string GetDrawing();
    }

    public class Vector : GraphicStyle
    {
        public override string GetDrawing() => "lines";
    }

    public class Raster : GraphicStyle
    {
        public override string GetDrawing() => "raster";
    }


    #endregion
}
