using CarTracker.Repository;
using CarTracker.Service.Common;
using CarTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CarTracker.Repository.Common;
using CarTracker.Common;

namespace CarTracker.Service
{
    public class CarService : ICarService
    {
        private ICarRepository CarRepository { get; set; }

        public CarService(ICarRepository carRepository)
        {
            CarRepository = carRepository;
        }

        public async Task<List<CarModel>> GetAllAsync(Paging paging, Sorting sorting/*, Filtering filtering*/)
        {
            return await CarRepository.GetAllAsync(paging, sorting/*, filtering*/);
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            return await CarRepository.GetAsync(id);
        }

        public async Task<bool> AddAsync(CarModel newCar)
        {
            return await CarRepository.AddAsync(newCar);
        }

        public async Task<bool> UpdateAsync(Guid id, CarModel updatedCar)
        {
            return await CarRepository.UpdateAsync(id, updatedCar);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await CarRepository.DeleteAsync(id);
        }
    }
}