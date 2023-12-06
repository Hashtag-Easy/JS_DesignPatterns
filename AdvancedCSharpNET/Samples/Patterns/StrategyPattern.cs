using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Samples.Patterns.Strategy
{
    #region dynamic strategy
    public enum OutputFormat
    {
        Markdown,
        Html
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class MarkdownListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            // markdown doesn't require a list preamble
        }

        public void End(StringBuilder sb)
        {

        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  <li>{item}</li>");
        }
    }

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Markdown:
                    listStrategy = new MarkdownListStrategy();
                    break;
                case OutputFormat.Html:
                    listStrategy = new HtmlListStrategy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
                listStrategy.AddListItem(sb, item);
            listStrategy.End(sb);
        }

        public StringBuilder Clear()
        {
            return sb.Clear();
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
    #endregion


    #region static strategy
    internal class StrategyPattern
    {
        static void Main(string[] args)
        {
            var shapeReader = new ShapeReaderStrategy(new EquilateralTriangle());
            Console.WriteLine("Shape is: {0}", shapeReader.GetName());
            shapeReader = new ShapeReaderStrategy(new Circle());
            Console.WriteLine("Shape is: {0}", shapeReader.GetName());
            shapeReader = new ShapeReaderStrategy(new Square());
            Console.WriteLine("Shape is: {0}", shapeReader.GetName());

            Console.ReadKey();
        }
    }

    public interface IShape
    {
        string GetShapeName();
    }
    
    public class ShapeReaderStrategy
    {
        private readonly IShape _shape;
        public ShapeReaderStrategy(IShape shape)
        {
            _shape = shape;
        }

        public string GetName()
        {
            return _shape.GetShapeName();
        }
    }

    public class Square : IShape
    {
        public string GetShapeName()
        {
            return "Square";
        }
    }
    public class Circle : IShape
    {
        public string GetShapeName()
        {
            return "Circle";
        }
    }
    public class EquilateralTriangle : IShape
    {
        public string GetShapeName()
        {
            return "Equilateral triangle";
        }
    }
    #endregion
}
