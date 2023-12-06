using System;

namespace DesignPatterns.Samples.Patterns.StatePattern
{
    #region state object
    public class Computer
    {
        private State _currentState;

        public Computer()
        {
            _currentState = new OffState();
        }

        public void PressPowerButton()
        {
            _currentState.PressPowerButton(this);
        }

        public void SetState(State state)
        {
            _currentState = state;
        }
    }

    public interface State
    {
        void PressPowerButton(Computer computer);
    }

    public class OnState : State
    {
        public void PressPowerButton(Computer computer)
        {
            Console.WriteLine("Computer is already on. Going to sleep mode...");
            computer.SetState(new SleepState());
        }
    }

    public class OffState : State
    {
        public void PressPowerButton(Computer computer)
        {
            Console.WriteLine("Turning on computer...");
            computer.SetState(new OnState());
        }
    }

    public class SleepState : State
    {
        public void PressPowerButton(Computer computer)
        {
            Console.WriteLine("Waking up computer from sleep mode...");
            computer.SetState(new OnState());
        }
    }

    public class TestState
    {
        public static void Main(string[] args)
        {
            Computer computer = new Computer();

            // Initial state is Off
            computer.PressPowerButton(); 

            // State is now On
            computer.PressPowerButton(); 

            // State is now Sleep
            computer.PressPowerButton(); 
        }
    }
    #endregion


    #region Card state
    internal class Account : IAccount
    {
        private float _cash;
        private ICardState _card;

        public Account(float cash)
        {
            _cash = cash;
            _card = SetCardType();
        }

        public void Withdraw(float cash)
        {
            if (cash > _cash
                || cash > _card.WithdrawLimit)
            {
                return;
            }

            _cash = _cash - cash;
            _cash = _cash - (_cash * _card.Interests);
            _card = SetCardType();
        }

        public void Deposit(float cash)
        {
            _cash = _cash + cash;
            _cash = _cash - (_cash * _card.Interests);
            _card = SetCardType();
        }

        public void Print()
        {
            _card.PrintBalance(_cash);
        }


        private ICardState SetCardType()
        {
            if (_cash >= 10000)
                return new VIPCard();
            else if (_cash >= 0)
                return new StandardCard();
            else
                return new DebtCard();
        }
    }

    internal interface IAccount
    {
        void Deposit(float cash);
        void Print();
        void Withdraw(float cash);
    }
    internal interface ICardState
    {
        float WithdrawLimit { get; }
        float Interests { get; }

        void PrintBalance(float cash);
    }

    internal class VIPCard : ICardState
    {
        public float Interests => 0.01f;

        public float WithdrawLimit => 5000.0f;

        public void PrintBalance(float cash)
        {
            Console.WriteLine("*** VIP client***");
            Console.WriteLine("Your account balance is {0}", cash);
            ProposeExtraCredit();
        }

        private void ProposeExtraCredit() { }
    }

    internal class StandardCard : ICardState
    {
        public float Interests => 0.03f;

        public float WithdrawLimit => 2000.0f;

        public void PrintBalance(float cash)
        {
            Console.WriteLine("*** Standard client***");
            Console.WriteLine("Your account balance is {0}", cash);
        }
    }

    internal class DebtCard : ICardState
    {
        public float Interests => 0.1f;

        public float WithdrawLimit => 0.0f;

        public void PrintBalance(float cash)
        {
            Console.WriteLine("*** Client ***");
            Console.WriteLine("Your account balance is {0}", cash);
            Console.WriteLine("You have 30 days to pay all your debt.");
            AddToBlacklist();
        }

        private void AddToBlacklist(){}
    }

    #endregion
}
