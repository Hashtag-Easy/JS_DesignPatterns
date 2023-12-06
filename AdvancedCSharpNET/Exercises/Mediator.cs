using System;

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
    public class Participant : IDisposable 
    {
        private readonly Mediator mediator;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            this.mediator.Alert += OnAlert;

            this.mediator.Alert += (o, e) => { Console.WriteLine($"My value is {e}"); }; // anonymous method A
            this.mediator.Alert -= (o, e) => { Console.WriteLine($"My value is {e}"); }; // anonymous method B

            EventHandler<int> someMethod = (o, e) => { Console.WriteLine($"My value is {e}"); };
            this.mediator.Alert += someMethod; // anonymous method D
            this.mediator.Alert -= someMethod; // anonymous method D

        }
        private void OnAlert(object sender, int value)
        {
            if (sender != this)
                Value += value;
        }

        public void Say(int n) => mediator.Broadcast(this, n);

        public void Dispose()
        {
            this.mediator.Alert -= OnAlert;
            this.mediator.Alert -= (o, e) => { Console.WriteLine($"My value is {e}"); }; // anonymous method C
        }
    }

    public class Mediator
    {
        public void Broadcast(object sender, int n) => Alert?.Invoke(sender, n);

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


            p1.Say(2);  // p1.Value = 0 p2.Value = 2 p3.Value = 2

            p2.Say(4); // p1.Value = 4 p2.Value = 2 p3.Value = 6

        }
    }
}
