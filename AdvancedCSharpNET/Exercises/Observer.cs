using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Exercises
{
    /*
     Implement kind of ObservableCollection on changing prices of a Market
     Print to console new prices as they are being added to the collection
     */
    public class Market
    {
        public List<float> Prices = new List<float>();
        
        public void AddPrice(float price)
        {
            //TODO
        }
        
        public event EventHandler<PriceAddedEventArgs> PriceAdded;
    }

    public class PriceAddedEventArgs
    {
        public float Price;
    }

    public class ObserverPattern
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            //TODO



            market.AddPrice(123);
            market.AddPrice(456);
            market.AddPrice(78);

        }
    }
}
