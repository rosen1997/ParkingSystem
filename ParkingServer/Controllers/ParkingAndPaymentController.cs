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
    public class ParkingAndPaymentController : Controller
    {
        private readonly IParkingStatusService parkingStatusService;

        public ParkingAndPaymentController(IParkingStatusService parkingStatusService)
        {
            this.parkingStatusService = parkingStatusService;
        }

        [HttpPost]
        [Route("EnterParking")]
        public IActionResult EnterParking([FromBody] ParkingStatusModel parkingStatusModel)
        {
            try
            {
                var parkingStatus = parkingStatusService.VehicleEntry(parkingStatusModel);
                return Ok(parkingStatus);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
