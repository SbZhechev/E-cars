using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_cars.Models
{
    public class Car
    {
        public string Picture { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Production_Year { get; set; }
        public int Mileage { get; set; }
        public int Price { get; set; }
    }
}
