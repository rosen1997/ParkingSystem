using ParkingServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Services.Interfaces
{
    public interface IParkingDataService
    {
        public ParkingDataModel Get();
        public ParkingDataModel UpdateData(ParkingDataModel parkingDataModel);
    }
}
