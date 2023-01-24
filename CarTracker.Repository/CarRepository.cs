using CarTracker.Model;
using CarTracker.Model.Common;
using CarTracker.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTracker.Repository
{
    public class CarRepository : ICarRepository
    {
        private string connectionString = "Server=DESKTOP-AT3ON5G\\BORINCI; Database=MonoDB; User Id=IvanMono; Password=mono123;";

        public async Task<List<CarModel>> GetAllAsync()
        {
            SqlConnection connection = null;
            try
            {
                string sqlQuery = "SELECT * FROM Car";
                connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                List<CarModel> cars = new List<CarModel>();
                while (await reader.ReadAsync())
                {
                    cars.Add(new CarModel()
                    {
                        Id = reader.GetGuid(0),
                        Manufacturer = reader.GetString(1),
                        Model = reader.GetString(2),
                        YearOfProduction = reader.GetInt32(3)
                    });
                }
                connection.Close();
                return cars;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            CarModel car = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                string sqlQuery = "SELECT * FROM Car WHERE Id='" + id + "'";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    car = new CarModel()
                    {
                        Id = reader.GetGuid(0),
                        Manufacturer = reader.GetString(1),
                        Model = reader.GetString(2),
                        YearOfProduction = reader.GetInt32(3)
                    };
                }
                return car;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> AddAsync(CarModel newCar)
        {
            SqlConnection connection = null;
            try
            {
                string sqlQuery = "INSERT INTO Car (Id, Manufacturer, Model, YearOfProduction) VALUES (@Id, @Manufacturer, @Model, @YearOfProduction)";
                connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                adapter.InsertCommand = command;
                command.Parameters.AddWithValue("@Id", newCar.Id);
                command.Parameters.AddWithValue("@Manufacturer", newCar.Manufacturer);
                command.Parameters.AddWithValue("@Model", newCar.Model);
                command.Parameters.AddWithValue("@YearOfProduction", newCar.YearOfProduction);
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> UpdateAsync(Guid id, CarModel updatedCar)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                string sqlQuery = "UPDATE Car SET Manufacturer = @Manufacturer, Model = @Model, YearOfProduction = @YearOfProduction WHERE Id = @Id";
                SqlCommand updateCommand = new SqlCommand(sqlQuery, connection);
                updateCommand.Parameters.AddWithValue("@Manufacturer", updatedCar.Manufacturer);
                updateCommand.Parameters.AddWithValue("@Model", updatedCar.Model);
                updateCommand.Parameters.AddWithValue("@YearOfProduction", updatedCar.YearOfProduction);
                updateCommand.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = updateCommand;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            SqlConnection connection = null;
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid id value. Id cannot be empty.");
            }
            try
            {
                connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                string deleteSqlQuery = "DELETE FROM Car WHERE Id = @Id";
                SqlCommand deleteCommand = new SqlCommand(deleteSqlQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Id", id);
                await deleteCommand.ExecuteNonQueryAsync();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}