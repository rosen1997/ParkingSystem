using ParkingServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Services.Interfaces
{
    public interface IPriceRangeService
    {
        public IEnumerable<PriceRange> GetAll();
        public void AddPriceRange(PriceRange priceRange);
    }
}
