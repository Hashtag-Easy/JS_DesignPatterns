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
        // todo - what would represent state of TokenMachine
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();


        //public Memento AddToken(Token token)
        //{
        //    // todo (yes, please do both overloads)
        //}

        public void Revert(Memento m)
        {
            // todo
        }
    }
}
