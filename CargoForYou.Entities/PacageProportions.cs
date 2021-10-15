using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CargoForYou.Entities
{
   public class PacageProportions
    {
        [Key]

        public int Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Depth { get; set; }

        public int Weight { get; set; }

        public double EstimatedPrice { get; set; }
    }
}
