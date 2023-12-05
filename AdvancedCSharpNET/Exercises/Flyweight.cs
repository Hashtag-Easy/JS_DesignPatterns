using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Exercises
{
    /* Typical use
      
     var sentence = new Sentence("hello world");
     sentence[1].Capitalize = true;
     Console.WriteLine(sentence); // writes "hello WORLD"

     */
    public class Sentence
    {
        private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            // todo
        }

        //public WordToken this[int index]
        //{
        //    get
        //    {
        //        // todo
        //    }
        //}

        //public override string ToString()
        //{
        //    // output formatted text here
        //}

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
