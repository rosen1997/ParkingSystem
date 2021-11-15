using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Entities
{
    [Table("RegisteredVehicles")]
    [Serializable]
    public class RegisteredVehicle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //TODO: make unique
        [Required]
        [MaxLength(10)]
        public string LicensePlate { get; set; }

        //Relations
        public int PriceRangeId { get; set; }
        public PriceRange PriceRange { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
