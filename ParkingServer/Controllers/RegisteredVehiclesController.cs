using Microsoft.AspNetCore.Mvc;
using ParkingServer.Models.EntityModels;
using ParkingServer.Repository.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisteredVehiclesController : Controller
    {
        private readonly IRegisteredVehicleService registeredVehicleService;

        public RegisteredVehiclesController(IRegisteredVehicleService registeredVehicleService)
        {
            this.registeredVehicleService = registeredVehicleService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var registeredVehicles = registeredVehicleService.GetAll();

            return Ok(registeredVehicles);
        }

        [HttpPost]
        [Route("RegisterVehicle")]
        public IActionResult RegisterVehicle([FromBody] RegisteredVehicleModel registeredVehicleModel)
        {
            try
            {
                var successfullyRegisteredVehicle = registeredVehicleService.RegisterVehicle(registeredVehicleModel);

                return Ok(successfullyRegisteredVehicle);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateRegisteredVehicleInformation")]
        public IActionResult UpdateRegisteredVehicleInformation([FromBody] RegisteredVehicleModel registeredVehicleModel)
        {
            try
            {
                var successfullyRegisteredVehicle = registeredVehicleService.UpdateRegisteredVehicleData(registeredVehicleModel);

                return Ok(successfullyRegisteredVehicle);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("RemoveRegisteredVehicle")]
        public IActionResult RemoveRegisteredVehicle([FromBody] RegisteredVehicleModel registeredVehicleModel)
        {
            try
            {
                registeredVehicleService.RemoveVehicle(registeredVehicleModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
