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
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeService vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        [Route("GetAllVehicleTypes")]
        public IActionResult GetAllVehicleTypes()
        {
            var vehicleTypes = vehicleTypeService.GetAll();

            return Ok(vehicleTypes);
        }

        [HttpPost]
        [Route("AddVehicleType")]
        public IActionResult AddVehicleType([FromBody] VehicleTypeModel vehicleTypeModel)
        {
            try
            {
                var createdVehicleType = vehicleTypeService.AddVehicleType(vehicleTypeModel);
                return Ok(createdVehicleType);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
