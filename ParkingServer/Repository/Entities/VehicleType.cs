using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Entities
{
    [Table("VehicleTypes")]
    [Serializable]
    public class VehicleType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Type { get; set; }

        public IEnumerable<RegisteredVehicle> RegisteredVehicles { get; set; }
    }
}
