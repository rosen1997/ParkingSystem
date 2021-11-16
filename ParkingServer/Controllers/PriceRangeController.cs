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
    public class PriceRangeController : Controller
    {
        private readonly IPriceRangeService priceRangeService;

        public PriceRangeController(IPriceRangeService priceRangeService)
        {
            this.priceRangeService = priceRangeService;
        }

        [HttpGet]
        [Route("GetAllPrices")]
        public IActionResult GetAllPrices()
        {
            var prices = priceRangeService.GetAll();

            return Ok(prices);
        }

        [HttpPost]
        [Route("AddPriceRange")]
        public IActionResult AddPriceRange([FromBody] PriceRangeModel priceRangeModel)
        {
            try
            {
                var addedPriceRange = priceRangeService.AddPriceRange(priceRangeModel);
                return Ok(addedPriceRange);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
