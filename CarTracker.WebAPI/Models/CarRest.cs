using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTracker.Model;

namespace CarTracker.WebAPI.Models
{
    public class CarRest
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }

        public static CarRest MapCarRest(CarModel car)
        {
            CarRest carRest = new CarRest()
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                YearOfProduction = car.YearOfProduction
            };
            return carRest;
        }
    }
}