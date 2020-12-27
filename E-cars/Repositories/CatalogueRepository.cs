using System;
using System.Collections.Generic;
using E_cars.Models;
using E_cars.Repositories;
using MySqlConnector;

namespace E_cars.Controllers
{
    public class CatalogueRepository : BaseRepository
    {
        private const string BASE_QUERY = "SELECT id, brand, model, production_year, price, milage, picture_path FROM cars";

        public CatalogueRepository() : base()
        {
        }

        //select models distinct
        public async System.Threading.Tasks.Task<List<string>> GetAllModelsAsync()
        {
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT DISTINCT model FROM cars;", connection);

            using var reader = await command.ExecuteReaderAsync();

            List<string> result = new List<string>();
            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
            await connection.CloseAsync();

            return result;
        }


        //select models distinct for brand
        public async System.Threading.Tasks.Task<List<string>> GetAllModelsForBrandAsync(string brand)
        {
            if (brand == null)
            {
                return new List<string>();
            }

            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT DISTINCT model FROM cars WHERE brand = @brand", connection);
            command.Parameters.AddWithValue("@brand", brand);

            using var reader = await command.ExecuteReaderAsync();

            List<string> result = new List<string>();
            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
            await connection.CloseAsync();

            return result;
        }

        //select brands distinct
        public async System.Threading.Tasks.Task<List<string>> GetAllBrandsAsync()
        {
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT DISTINCT brand FROM cars;", connection);

            using var reader = await command.ExecuteReaderAsync();

            List<string> result = new List<string>();
            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
            await connection.CloseAsync();

            return result;
        }

        //select total cars
        public async System.Threading.Tasks.Task<List<Car>> GetAllAsync()
        {
            await connection.OpenAsync();

            using var command = new MySqlCommand(BASE_QUERY + ";", connection);

            using var reader = await command.ExecuteReaderAsync();

            List<Car> result = new List<Car>();
            while (await reader.ReadAsync())
            {
                result.Add(BuildCarEntity(reader));
            }
            await connection.CloseAsync();

            return result;
        }

        //select all cars for the selected filters
        public async System.Threading.Tasks.Task<List<Car>> GetAllCarsForFilters(CarFilter filter)
        {
            await connection.OpenAsync();

            var query = BuildQuery(filter);

            using var command = new MySqlCommand(query, connection);

            if (filter != null)
            {
                command.Parameters.AddWithValue("@brand", filter.Brand);
                command.Parameters.AddWithValue("@model", filter.Model);
            }



            using var reader = await command.ExecuteReaderAsync();

            List<Car> result = new List<Car>();
            while (await reader.ReadAsync())
            {
                result.Add(BuildCarEntity(reader));
            }
            await connection.CloseAsync();

            return result;
        }

        private string BuildQuery(CarFilter carFilter)
        {
            string query = BASE_QUERY;

            if (carFilter == null)
            {
                return query;
            }

            List<string> filters = new List<string>();

            if (carFilter.Brand != null)
            {
                filters.Add(" brand = @brand ");
            }
            if (carFilter.Model != null)
            {
                filters.Add(" model = @model ");
            }

            if (filters.Count != 0)
            {
                return BASE_QUERY + " WHERE " + String.Join(" AND ", filters.ToArray()) + ";";
            }
            else
            {
                return BASE_QUERY;
            }
        }


        private Car BuildCarEntity(MySqlDataReader reader)
        {
            Car car = new Car
            {
                Id = reader.GetInt16(0),
                Brand = reader.GetString(1),
                Model = reader.GetString(2),
                Production_Year = reader.GetInt16(3),
                Price = reader.GetDouble(4),
                Mileage = reader.GetDouble(5),
                Picture = reader.GetString(6)
            };

            return car;
        }
    }


}
