using CarTracker.Common;
using CarTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTracker.Repository.Common
{
    public interface ICarRepository
    {
        Task<List<CarModel>> GetAllAsync(Paging paging, Sorting sorting/*, Filtering filtering*/);
        Task<CarModel> GetAsync(Guid id);
        Task<bool> AddAsync(CarModel newCar);
        Task<bool> UpdateAsync(Guid id, CarModel updatedCar);
        Task<bool> DeleteAsync(Guid id);
    }
}