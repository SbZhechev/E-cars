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

            List<string> brands = await catalogueRepository.GetAllBrandsAsync();
            List<string> models = await catalogueRepository.GetAllModelsAsync();
            ViewBag.brands = brands;
            ViewBag.carModels = models;

            List<Car> carsnull = await catalogueRepository.GetAllCarsForFilters(null);

            return View(cars);
        }

        public async Task<IActionResult> Brand(string brand, string model)
        {
            List<string> brands = await catalogueRepository.GetAllBrandsAsync();
            List<string> models = await catalogueRepository.GetAllModelsAsync();
            ViewBag.brands = brands;
            ViewBag.carModels = models;

            ViewBag.selectedModel = model != null ? model : "Изберете модел";
            ViewBag.selectedBrand = brand != null ? brand : "Изберете марка";

            CarFilter carFilter = new CarFilter();
            carFilter.Brand = brand;
            carFilter.Model = model;
            List<Car> carWithFilters = await catalogueRepository.GetAllCarsForFilters(carFilter);

            return View(carWithFilters);
        }

    }
}
