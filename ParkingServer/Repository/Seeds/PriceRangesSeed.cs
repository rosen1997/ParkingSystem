using ParkingServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Seeds
{
    public static class PriceRangesSeed
    {
        public static PriceRange[] Seed()
        {
            return new PriceRange[]
            {
                new PriceRange{Id=1, Price=0.00},
                new PriceRange{Id=2, Price=0.50},
                new PriceRange{Id=3, Price=1.00},
            };
        }
    }
}
