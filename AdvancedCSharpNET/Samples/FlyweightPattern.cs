using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples
{
    public class TextEditor
    {
        private string _text = string.Empty;
        private List<FontCapital> _capitals = new List<FontCapital>();

        public void AppendText(string text)
        {
            _text += text;
        }

        public void Bold(int startSelection, int selectionLength) 
        {
            _capitals.Add(new FontCapital { StartIndex = startSelection, Length = selectionLength });
        }
                
        public void Print()
        {
            var formattedText = _text;
            foreach (var font in _capitals) 
            {
                var partialText = ToUpper(formattedText.Substring(font.StartIndex, font.Length));

                formattedText.Remove(font.StartIndex, font.Length);
                formattedText.Insert(font.StartIndex, partialText);
            }

            Console.WriteLine(formattedText);
        }

        private string ToUpper(string input)
        {
            return input.ToUpper();
        }
    }


    public class FontCapital
    {
        public int StartIndex { get; set; }
        public int Length { get; set; }
    }






    internal class StringFlyweitghPattern
    {
        public void Mth()
        {
            var str1 = new string("Hi there");
            var str2 = new string("Hi there");

            var result = str1 == str2; //true
        }
    }
}
