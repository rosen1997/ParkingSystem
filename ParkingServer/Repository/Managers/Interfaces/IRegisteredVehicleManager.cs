﻿using ParkingServer.Repository.Entities;
using ParkingServer.Repository.RepositoryBaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Managers.Interfaces
{
    public interface IRegisteredVehicleManager : IRepositoryBase<RegisteredVehicle>
    {
        public IEnumerable<RegisteredVehicle> GetAllWithRelations();
        public RegisteredVehicle GetByLicensePlate(string licensePlate);
    }
}
