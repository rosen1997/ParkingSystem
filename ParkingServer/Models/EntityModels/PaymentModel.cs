using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParkingServer.Models.EntityModels
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public int ParkingStatusId { get; set; }

        [JsonIgnore]
        public ParkingStatusModel ParkingStatus { get; set; }
    }
}
