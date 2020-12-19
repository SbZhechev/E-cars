using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static E_cars.Controllers.DBManipulator;
using E_cars.Models;

namespace E_cars.Controllers
{
    public class Catalogue : Controller
    {
        public IActionResult Index()
        {
            Car car = new Car();
            car.Picture = "/mercedes-cls.jpg";
            car.Brand = "Mercedes";
            car.Model = "CLS 500";
            car.Production_Year = 2018;
            car.Mileage = 10;
            car.Price = 50000;

            Car car2 = new Car();
            car2.Picture = "/mercedes-cls.jpg";
            car2.Brand = "BMW";
            car2.Model = "E46";
            car2.Production_Year = 1998;
            car2.Mileage = 123456;
            car2.Price = 8000;

            List<Car> myCars = new List<Car>();
            myCars.Add(car);
            myCars.Add(car2);

            return View(myCars);
        }
    }
}
