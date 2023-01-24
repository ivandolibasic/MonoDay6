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
using CarTracker.Service.Common;
using Autofac.Core;

namespace CarTracker.WebAPI.Controllers
{
    public class CarController : ApiController
    {
        private ICarService CarService { get; set; }

        public CarController(ICarService carService)
        {
            CarService = carService;
        }

        //GET api/Car
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            List<CarModel> cars = await CarService.GetAllAsync();
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

        //GET api/Car?id=
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync(Guid id)
        {
            CarModel car = await CarService.GetAsync(id);
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
                CarRest carRest = new CarRest()
                {
                    Id = newCar.Id,
                    Manufacturer = newCar.Manufacturer,
                    Model = newCar.Model,
                    YearOfProduction = newCar.YearOfProduction
                };
                bool result = await CarService.AddAsync(carRest.MapCar());
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

        //PUT api/Car?id=
        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(Guid id, [FromBody] CarRest updatedCar)
        {
            if (updatedCar != null)
            {
                bool result = await CarService.UpdateAsync(id, updatedCar.MapCar());
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

        //DELETE api/Car?id=
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAsync([FromUri] Guid id)
        {
            bool result = await CarService.DeleteAsync(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}