using System;
using System.Collections.Generic;
using System.Text;

namespace CargoForYou.Entities
{
   public class MaltaShip : ICargoForYouService
    {
        int volume;
        int weight;
        double pricePerKg = 0.41;
       public MaltaShip(int volume, int weight)
        {
            this.volume = volume;
            this.weight = weight;
        }
        public double getPrice()
        {
            if ((this.weight < 10) || this.volume<500)
            {
                return 0;
            }

            double pricePerVolume = 0;

            if (volume <= 1000)
            {
                pricePerVolume = 9.5;
            }else if(this.volume <= 2000)
            {
                pricePerVolume = 19.5;
            }else if (this.volume <= 5000)
            {
                pricePerVolume = 48.5;
            }else
            {
                pricePerVolume = 147.5;
            }

            double pricePerWeight = 0;

            if (this.weight < 20)
            {
                pricePerWeight = 16.99;
            }else if( this.weight < 30)
            {
                pricePerWeight = 33.99;
            }else 
            {
                pricePerWeight = 43.99;
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
