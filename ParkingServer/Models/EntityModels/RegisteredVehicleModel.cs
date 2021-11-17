using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Models.EntityModels
{
    public class RegisteredVehicleModel
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }

        public int PriceRangeId { get; set; }
        public PriceRangeModel PriceRange { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleTypeModel VehicleType { get; set; }
    }
}
