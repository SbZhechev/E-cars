using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using static E_cars.Controllers.DBManipulator;
using E_cars.Models;

namespace E_cars.Controllers
{
    public class Catalogue : Controller
    {
        CatalogueRepository catalogueRepository = new CatalogueRepository();

        public async Task<IActionResult> IndexAsync()
        {

            List<Car> cars = await catalogueRepository.GetAllAsync();

            return View(cars);
        }

        public IActionResult Brand(string brand)
        {
            ViewBag.selectedBrand = brand;
            return View();
        }
    }
}
