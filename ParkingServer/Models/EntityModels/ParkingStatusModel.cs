using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Models.EntityModels
{
    public class ParkingStatusModel
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime TimeOfArrival { get; set; }

        public DateTime? TimeOfLeave { get; set; }

        //Relations
        public int? RegisteredVehicleId { get; set; }
        public RegisteredVehicleModel RegisteredVehicle { get; set; }

        public int PriceRangeId { get; set; }
        public PriceRangeModel PriceRange { get; set; }
    }
}
