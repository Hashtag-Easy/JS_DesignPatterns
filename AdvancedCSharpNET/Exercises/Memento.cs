using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Exercises
{
    /*
    A TokenMachine is in charge of keeping tokens. 
    Each Token  is a reference type with a single numerical value. 
    The machine supports adding tokens and, when it does, 
    it returns a memento representing the state of that system at that given time.

    Fill up gaps
     */

    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<Token> Tokens { get; set; }

        public Memento(IEnumerable<Token> tokens)
        {
            Tokens = tokens.Select(t => new Token(t.Value)).ToList();
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();


        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return new Memento(Tokens);
        }

        public void Revert(Memento m)
        {
            Tokens = m.Tokens.Select(t => new Token(t.Value)).ToList();
        }
    }
}
