using System;

namespace DesignPatterns.Samples.Patterns.MediatR
{

    public interface IMediator
    {
        void SendMessage(string message, ICollegue collegue);
    }

    public interface ICollegue
    {
        void Send(string message);
        void GetMessage(string message);
    }

    public class ConcreteColleague1 : ICollegue
    {
        private IMediator _mediator;

        public ConcreteColleague1(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void GetMessage(string message)
        {
            Console.WriteLine($"Colleague1 got message: {message}");
        }

        public void Send(string message)
        {
            _mediator.SendMessage(message, this);
        }
    }

    public class ConcreteColleague2 : ICollegue
    {
        private IMediator _mediator;

        public ConcreteColleague2(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void GetMessage(string message)
        {
            Console.WriteLine($"Colleague2 got message: {message}");
        }

        public void Send(string message)
        {
            _mediator.SendMessage(message, this);
        }
    }

    public class ConcreteMediator : IMediator
    {
        public ICollegue Collegue1 { get; set; }
        public ICollegue Collegue2 { get; set; }

        public void SendMessage(string message, ICollegue collegue)
        {
            if (collegue == Collegue1)
            {
                Collegue2.GetMessage(message);
            }
            else
            {
                Collegue1.GetMessage(message);
            }
        }
    }
}
