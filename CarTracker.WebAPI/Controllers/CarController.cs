using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Http;
using CarTracker.Service;
using CarTracker.Model;
using CarTracker.WebAPI.Models;
using System.Threading.Tasks;

namespace CarTracker.WebAPI.Controllers
{
    public class CarController : ApiController
    {
        private static CarService carService = new CarService();

        //GET api/Car
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            List<CarModel> cars = await carService.GetAllAsync();
            if (cars.Any())
            {
                List<CarRest> carRests = new List<CarRest>();
                foreach (var car in cars)
                {
                    carRests.Add(CarRest.MapCarRest(car));
                }
                return Request.CreateResponse(HttpStatusCode.OK, carRests);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        //GET api/Car?id=7E2DCB8F-8D83-4F64-9AE5-3F7BE66BB4A8
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync(Guid id)
        {
            CarModel car = await carService.GetAsync(id);
            if (car != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, CarRest.MapCarRest(car));
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        //POST api/Car
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromBody] CarRest newCar)
        {
            if (newCar != null)
            {
                CarModel carModel = new CarModel()
                {
                    Id = newCar.Id,
                    Manufacturer = newCar.Manufacturer,
                    Model = newCar.Model,
                    YearOfProduction = newCar.YearOfProduction
                };
                bool result = await carService.AddAsync(carModel);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //PUT api/Car?id=7E2DCB8F-8D83-4F64-9AE5-3F7BE66BB4A8
        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(Guid id, [FromBody] CarModel updatedCar)
        {
            if (updatedCar != null)
            {
                bool result = await carService.UpdateAsync(id, updatedCar);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //DELETE api/Car?id=7E2DCB8F-8D83-4F64-9AE5-3F7BE66BB4A8
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            bool result = await carService.DeleteAsync(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}