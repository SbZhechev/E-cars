using System;
using MySqlConnector;

namespace E_cars.Repositories
{
    public class BaseRepository
    {
        protected MySqlConnection connection;

        public BaseRepository()
        {
            connection = new MySqlConnection("server=localhost;user=root;password=root;database=e_cars");
        }

    }
}
