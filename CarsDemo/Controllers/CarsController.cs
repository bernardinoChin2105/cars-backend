using CarsDemo.Models;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private AppContext _appContext;
        public CarsController(AppContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var Response = this._appContext.Cars.AsNoTracking().Select(c => new CarsResponse
                {
                    CarId = c.Id,
                    Name = c.Name,
                    Model = c.Model,
                    Year = c.Year
                });

                return Ok(Response);
            }
            catch
            {
                return BadRequest(HttpStatusCode.InternalServerError);
            }
        }


        [HttpPost]
        public ActionResult Post(CarsRequest Car)
        {
            try
            {
                var existingItem = _appContext.Cars.FirstOrDefault(x => x.Name.ToLower() == Car.Name.ToLower() && x.Model.ToLower() == Car.Model.ToLower() && x.Year == Car.Year);
                if (existingItem != null)
                    return BadRequest("There exist a car with the same characteristics.");

                var NewCar = new Car()
                {
                    Name = Car.Name,
                    Model = Car.Model,
                    Year = Car.Year
                };
                _appContext.Add(NewCar);
                _appContext.SaveChanges();

                var CarResponse = new CarsResponse()
                {
                    CarId = NewCar.Id,
                    Name = NewCar.Name,
                    Model = NewCar.Model,
                    Year = NewCar.Year
                };
                return Ok(CarResponse);
            }
            catch
            {
                return BadRequest(HttpStatusCode.InternalServerError);
            }
        }
    }
}
