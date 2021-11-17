using ParkingServer.Models;
using ParkingServer.Models.EntityModels;
using ParkingServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        public IEnumerable<VehicleTypeModel> GetAll();
        public VehicleTypeModel AddVehicleType(VehicleTypeModel vehicleTypeModel);
    }
}
