using System.Collections.Generic;

namespace DesignPatterns.Exercises
{
    /* Typical use
      
     var sentence = new Sentence("hello world");
     sentence[1].Capitalize = true;
     Console.WriteLine(sentence); // writes "hello WORLD"

     */
    public class Sentence
    {
        private readonly string[] _words;
        private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            _words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                if (!tokens.TryGetValue(index, out WordToken value))
                {
                    value = new WordToken();
                    tokens.Add(index, value);
                }

                return value;
            }
        }

        public override string ToString()
        {
            var words = new List<string>();

            for (int i = 0; i < _words.Length; i++)
            {
                if(tokens.ContainsKey(i) && tokens[i].Capitalize)
                {
                    words.Add(_words[i].ToUpper());
                }
                {
                    words.Add(_words[i]);
                }
            }

            return string.Join(' ', words);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
