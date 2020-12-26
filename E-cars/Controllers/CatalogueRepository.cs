using System;
using System.Collections.Generic;
using E_cars.Models;
using MySqlConnector;

namespace E_cars.Controllers
{
    public class CatalogueRepository
    {
        MySqlConnection connection;

        public CatalogueRepository()
        {
            connection = new MySqlConnection("server=localhost;user=root;password=root;database=e_cars");
        }

        public async System.Threading.Tasks.Task<List<Car>> GetAllAsync()
        {
            await connection.OpenAsync();

            using var command = new MySqlCommand("SELECT id, brand, model, production_year, price, milage, picture_path FROM cars;", connection);

            using var reader = await command.ExecuteReaderAsync();

            List<Car> result = new List<Car>();
            while (await reader.ReadAsync())
            {
                result.Add(BuildCarEntity(reader));
            }
            await connection.CloseAsync();

            return result;
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
