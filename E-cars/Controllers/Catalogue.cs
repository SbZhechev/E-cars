using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using static E_cars.Controllers.DBManipulator;
using E_cars.Models;

namespace E_cars.Controllers
{
    public class Catalogue : Controller
    {
        public IActionResult Index()
        {
            Car car = new Car();
            car.Picture = "/kia-stinger.jpg";
            car.Brand = "Mercedes";
            car.Model = "CLS 500";
            car.Production_Year = 2018;
            car.Mileage = 10;
            car.Price = 50000;

            Car car2 = new Car();
            car2.Picture = "/bmw-4.jpg";
            car2.Brand = "BMW";
            car2.Model = "E46";
            car2.Production_Year = 1998;
            car2.Mileage = 15;
            car2.Price = 8000;

            Car car3 = new Car();
            car3.Picture = "/audi-r8.jpg";
            car3.Brand = "Audi";
            car3.Model = "R8";
            car3.Production_Year = 2020;
            car3.Mileage = 20;
            car3.Price = 200000;

            Car car4 = new Car();
            car4.Picture = "/lada-riva.jpg";
            car4.Brand = "Lada";
            car4.Model = "Riva";
            car4.Production_Year = 1995;
            car4.Mileage = 500000;
            car4.Price = 2000;

            List<Car> myCars = new List<Car>();
            myCars.Add(car);
            myCars.Add(car2);
            myCars.Add(car3);
            myCars.Add(car4);

            return View(myCars);
        }

        public IActionResult Brand(string brand)
        {
            ViewBag.selectedBrand = brand;
            return View();
        }
    }
}
