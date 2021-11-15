using ParkingServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Seeds
{
    public static class VehicleTypesSeed
    {
        public static VehicleType[] Seed()
        {
            return new VehicleType[]
            {
                new VehicleType{Id=1, Type="Ambulance"},
                new VehicleType{Id=2, Type="Police Car"},
                new VehicleType{Id=3, Type="Fire Truck"},
                new VehicleType{Id=4, Type="Ambulance"},
                new VehicleType{Id=5, Type="Company Car"},
                new VehicleType{Id=6, Type="Paid Subscription"},
            };
        }
    }
}
