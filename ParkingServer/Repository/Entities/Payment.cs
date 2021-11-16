using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Entities
{
    [Table("Payments")]
    [Serializable]
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public double PaymentAmount { get; set; }


        public int ParkingStatusId { get; set; }
        public ParkingStatus ParkingStatus { get; set; }
    }
}
