using System;
using System.Collections.Generic;
using System.Text;

namespace CargoForYou.Entities
{
   public class ShipFaster : ICargoForYouService
    {
        int volume;
        int weight;
        double pricePerKg = 0.417;
       public ShipFaster(int volume, int weight)
        {
            this.volume = volume;
            this.weight = weight;
        }
        public double getPrice()
        {
            if ((this.weight <= 10 && this.weight>30)|| this.volume>1700)
            {
                return 0;
            }

            double pricePerVolume = 0;

            if (volume <= 1000)
            {
                pricePerVolume = 11.99;
            }else 
            {
                pricePerVolume = 21.99;
            }

            double pricePerWeight = 0;

            if (this.weight < 15)
            {
                pricePerWeight = 16.5;
            }else if( this.weight < 25)
            {
                pricePerWeight = 36.5;
            }else 
            {
                pricePerWeight = 40;
                double extraWeight = this.weight - 25;
                pricePerWeight += Math.Ceiling(extraWeight) * this.pricePerKg;
            }

            double price = pricePerVolume;

            if (pricePerWeight > pricePerVolume)
            {
                price = pricePerWeight;
            }


            return price;
        }
    }
}
