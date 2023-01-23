﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarTracker.Model;

namespace CarTracker.Service.Common
{
    public interface ICarService
    {
        Task<List<CarModel>> GetAllAsync();
        Task<CarModel> GetAsync(Guid id);
        Task<bool> AddAsync(CarModel newCar);
        Task<bool> UpdateAsync(Guid id, CarModel updatedCar);
        Task<bool> DeleteAsync(Guid id);
    }
}