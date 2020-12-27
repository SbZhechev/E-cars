using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using static E_cars.Controllers.DBManipulator;
using E_cars.Models;
using E_cars.Services;

namespace E_cars.Controllers
{
    public class Catalogue : Controller
    {
        CatalogueRepository catalogueRepository = new CatalogueRepository();
        CatalogueService catalogueService = new CatalogueService();

        public async Task<IActionResult> IndexAsync()
        {
            List<Car> cars = await catalogueRepository.GetAllAsync();

            List<string> brands = await catalogueRepository.GetAllBrandsAsync();
            List<string> models = await catalogueRepository.GetAllModelsAsync();

            ViewBag.brands = brands;
            ViewBag.carModels = models;

            return View(cars);
        }

        public async Task<IActionResult> Brand(string brand, string model)
        {
            List<string> brands = await catalogueRepository.GetAllBrandsAsync();
            ViewBag.brands = brands;

            ViewBag.selectedModel = model != null ? model : "Изберете модел";
            ViewBag.selectedBrand = brand != null ? brand : "Изберете марка";
            CarFilter carFilter = new CarFilter();
            carFilter.Brand = brand;
            carFilter.Model = model;
            List<Car> carWithFilters = await catalogueRepository.GetAllCarsForFilters(carFilter);

            if (brand != null)
            {
                List<string> models = await catalogueRepository.GetAllModelsForBrandAsync(brand);
                ViewBag.carModels = models;
            } else
            {
                List<string> models = await catalogueRepository.GetAllModelsAsync();
                ViewBag.carModels = models;
            }

            return View(carWithFilters);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            List<Car> cars = await catalogueService.SearchCarsAsync(searchString);
            return View(cars);
        }
    }
}
