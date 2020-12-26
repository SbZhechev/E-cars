using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_cars.Models
{
    public class Car
    {

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Production_Year { get; set; }
        public double Price { get; set; }
        public double Mileage { get; set; }
        public string Picture { get; set; }
    }
}
