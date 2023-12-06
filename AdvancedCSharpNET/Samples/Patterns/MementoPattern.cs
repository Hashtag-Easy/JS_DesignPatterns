using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Samples.Patterns.Memento
{
    public class Originator
    {
        int _statesnap;
        public int State
        {
            get { return _statesnap; }
            set
            {
                _statesnap = value;
                Console.WriteLine("State is " + _statesnap);
            }
        }

        public Memento CreateMemento()
        {
            return new Memento(_statesnap);
        }

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("The Previous State was: ");
            State = memento.Statesnap;
        }
    }

    public class Memento
    {
        int _statesnap;

        public Memento(int statesnap)
        {
            this._statesnap = statesnap;
        }

        public int Statesnap
        {
            get { return _statesnap; }
        }
    }

    public class Caretaker
    {
        //may be implemented as stack
        Memento memento;
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }



    public class Demo
    {
        public static void Main(string[] args) 
        {
            Originator origin = new Originator();
            Random rand = new Random();
            origin.State = rand.Next(1000000);

            // Creating a Memento
            Caretaker caret = new Caretaker();
            caret.Memento = origin.CreateMemento();

            //Changing the state
            origin.State = rand.Next(1000000);

            // Restoring the State
            origin.RestoreMemento(caret.Memento);

            // Wait for user
            Console.ReadKey();
        }
    }
}
