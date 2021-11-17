using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Entities
{
    [Table("ParkingStatus")]
    [Serializable]
    public class ParkingStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string LicensePlate { get; set; }

        [Required]
        public DateTime TimeOfArrival { get; set; }

        public DateTime? TimeOfLeave { get; set; }

        //Relations
        public int? RegisteredVehicleId { get; set; }
        public RegisteredVehicle RegisteredVehicle { get; set; }

        public int PriceRangeId { get; set; }
        public PriceRange PriceRange { get; set; }

        public Payment Payment { get; set; }
    }
}
