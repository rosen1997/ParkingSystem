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
    public class ParkingDataController : Controller
    {
        private readonly IParkingDataService parkingDataService;

        public ParkingDataController(IParkingDataService parkingDataService)
        {
            this.parkingDataService = parkingDataService;
        }


        [HttpGet]
        [Route("GetParkingData")]
        public IActionResult GetParkingData()
        {
            var parkingData = parkingDataService.Get();
            return Ok(parkingData);
        }

        [HttpPost]
        [Route("UpdateParkingData")]
        public IActionResult UpdateParkingData([FromBody] ParkingDataModel parkingDataModel)
        {
            try
            {
                var updatedData = parkingDataService.UpdateData(parkingDataModel);
                return Ok(updatedData);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
