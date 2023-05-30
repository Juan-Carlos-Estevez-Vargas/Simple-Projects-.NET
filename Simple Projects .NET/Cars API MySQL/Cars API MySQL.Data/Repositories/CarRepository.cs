﻿using Cars_API_MySQL.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Cars_API_MySQL.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public CarRepository()
        {
        }

        public CarRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCar(Car car)
        {
            var db = dbConnection();

            var sql = @" DELETE FROM cars WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new {Id = car.Id});

            return result > 0;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var db = dbConnection();

            var sql = @" SELECT id, make, model, color, year, doors FROM cars";

            return await db.QueryAsync<Car>(sql, new { });
        }

        public async Task<Car> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, make, model, color, year, doors FROM cars WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id });
        }

        public async Task<bool> InsertCar(Car car)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO cars(make, model, color, year, doors) 
                        VALUES (@Make, @Model, @Color, @Year, @Doors)";

            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors });

            return result > 0;
        }

        public async Task<bool> UpdateCar(Car car)
        {
            var db = dbConnection();

            var sql = @" UPDATE cars SET make = @Make, model = @Model, color = @Color, year = @Year, doors = @Doors) 
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors, car.Id });

            return result > 0;
        }
    }
}
