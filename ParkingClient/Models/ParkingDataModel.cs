using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingClient.Models
{
    public class ParkingDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AllSpaces { get; set; }
        public int FreeSpacesLeft { get; set; }
    }
}
