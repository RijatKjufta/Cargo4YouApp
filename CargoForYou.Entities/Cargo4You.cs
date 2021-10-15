using System;
using System.Collections.Generic;
using System.Text;

namespace CargoForYou.Entities
{
   public class Cargo4You : ICargoForYouService
    {
        int volume;
        int weight;
       public Cargo4You(int volume, int weight)
        {
            this.volume = volume;
            this.weight = weight;
        }
        public double getPrice()
        {
            if (this.weight > 20 || this.volume>2000)
            {
                return 0;
            }

            double pricePerVolume = 0;

            if (volume <= 1000)
            {
                pricePerVolume = 10;
            }else 
            {
                pricePerVolume = 20;
            }

            double pricePerWeight = 0;

            if (this.weight < 2)
            {
                pricePerWeight = 15;
            }else if( this.weight < 15)
            {
                pricePerWeight = 18;
            }else 
            {
                pricePerWeight = 35;
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
