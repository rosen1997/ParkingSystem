using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Entities
{
    [Table("PriceRange")]
    [Serializable]
    public class PriceRange
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double Price { get; set; }

        public IEnumerable<RegisteredVehicle> RegisteredVehicles { get; set; }
    }
}
