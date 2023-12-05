using System;

namespace DesignPatterns.Samples.Patterns
{
    #region straight through implementation
    public class Context
    {
        public string StringToParse { get; set; }
        public Context(string stringToParse)
        {
            StringToParse = stringToParse;
        }
    }

    public interface IExpression
    {
        void Interpret(Context context);
    }

    public class TerminalExpression : IExpression
    {
        public void Interpret(Context context)
        {
            Console.WriteLine("Terminal Expression " +
                "Output in {0}.", context.StringToParse);
        }
    }

    public class NonterminalExpression : IExpression
    {
        public IExpression Expression1 { get; set; }
        public IExpression Expression2 { get; set; }

        public void Interpret(Context context)
        {
            Console.WriteLine("Nonterminal Expression " +
                "Output in {0}.", context.StringToParse);
            Expression1.Interpret(context);
            Expression2.Interpret(context);
        }
    }
    #endregion

    #region number interpreter
    public class NumberContext
    {
        public int Number { get; set; }
        public string Result { get; set; } = string.Empty;

        public NumberContext(int number)
        {
            Number = number;
        }

    }
    public interface INumberExpression
    {
        public void Interpret(NumberContext context);
    }
    public class NumberExpresion : INumberExpression
    {
        public void Interpret(NumberContext context)
        {
            var stringNumber = context.Number.ToString();

            var numberTranslations = new string[]
                {"Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine"
                };

            foreach (var character in stringNumber)
            {
                context.Result += $"{numberTranslations[int.Parse(character.ToString())]}-";
            }
            context.Result = context.Result.Remove(context.Result.Length - 1);
        }
    }


    public class InterpreterTest
    {
        public static void Main(string[] args)
        {
            var expression = new NumberExpresion();
            var output = new NumberContext(3456);

            expression.Interpret(output);

            string result = output.Result;
            Console.WriteLine("The string is:");
            Console.WriteLine(result);
        }
    }
    #endregion
}
