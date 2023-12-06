using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Exercises
{
    /*
     A participant can 'Say()' a particular value, which is broadcast to all other participants. 
    At this point in time, every other participant is obliged to increase their Value by the value being broadcast.

    Example:
    Two participants start with values 0 and 0 respectively
    Participant 1 broadcasts the value 3. We now have Participant 1 value = 0, Participant 2 value = 3
    Participant 2 broadcasts the value 2. We now have Participant 1 value = 2, Participant 2 value = 3
     */
    public class Participant
    {
        private readonly Mediator mediator;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            //TODO
        }


        public void Say(int n)
        {
            //TODO
        }
    }

    public class Mediator
    {
        public void Broadcast(object sender, int n)
        {
            //TODO
        }

        public event EventHandler<int> Alert;
    }


    public class TestMediator
    {
        public void Test()
        {
            Mediator mediator = new Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);
            var p3 = new Participant(mediator);


            p1.Say(2);

            p2.Say(4);

        }
    }
}
