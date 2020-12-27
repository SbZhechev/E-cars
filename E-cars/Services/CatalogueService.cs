using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_cars.Controllers;
using E_cars.Models;

namespace E_cars.Services
{
    public class CatalogueService
    {
        private CatalogueRepository catalogueRepo;

        public CatalogueService()
        {
            catalogueRepo = new CatalogueRepository();
        }

        public async Task<List<Car>> SearchCarsAsync(string filter)
        {
            if (filter == null)
            {
                return new List<Car>();
            }

            List<Car> searchResults = new List<Car>();
            foreach (string word in filter.Split(" "))
            {
                List<Car> dbRes = await catalogueRepo.SearchCarForFilterAsync(word);
                List<int> alreadyAddedRecords = searchResults.ConvertAll(new Converter<Car, int>(ConvertToId));

                foreach (Car car in dbRes)
                {
                    if (!alreadyAddedRecords.Contains(car.Id))
                    {
                        searchResults.Add(car);
                    }
                }
            }

            return searchResults;
        }
        private int ConvertToId(Car a)
        {
            return a.Id;
        }
    }
}
