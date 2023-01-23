using CarTracker.Repository;
using CarTracker.Service.Common;
using CarTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CarTracker.Service
{
    public class CarService : ICarService
    {
        CarRepository carRepository = new CarRepository();

        public async Task<List<CarModel>> GetAllAsync()
        {
            return await carRepository.GetAllAsync();
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            return await carRepository.GetAsync(id);
        }

        public async Task<bool> AddAsync(CarModel newCar)
        {
            return await carRepository.AddAsync(newCar);
        }

        public async Task<bool> UpdateAsync(Guid id, CarModel updatedCar)
        {
            return await carRepository.UpdateAsync(id, updatedCar);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await carRepository.DeleteAsync(id);
        }
    }
}