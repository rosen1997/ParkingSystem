using ParkingServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Services.Interfaces
{
    public interface IRegisteredVehicleService
    {
        public IEnumerable<RegisteredVehicleModel> GetAll();
        public RegisteredVehicleModel RegisterVehicle(RegisteredVehicleModel registeredVehicleModel);
        public void RemoveVehicle(RegisteredVehicleModel registeredVehicleModel);
        public RegisteredVehicleModel UpdateRegisteredVehicleData(RegisteredVehicleModel registeredVehicleModel);
    }
}
