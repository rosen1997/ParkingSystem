using Microsoft.EntityFrameworkCore;
using ParkingServer.Repository.Entities;
using ParkingServer.Repository.Managers.Interfaces;
using ParkingServer.Repository.RepositoryBaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Managers
{
    public class RegisteredVehicleManager : RepositoryBase<RegisteredVehicle>, IRegisteredVehicleManager
    {
        public RegisteredVehicleManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<RegisteredVehicle> GetAllWithRelations()
        {
            return RepositoryContext.RegisteredVehicles
                .Include(x => x.PriceRange)
                .Include(x => x.VehicleType);
        }

        public RegisteredVehicle GetByLicensePlate(string licensePlate)
        {
            return RepositoryContext.RegisteredVehicles.Where(x => x.LicensePlate.Equals(licensePlate))
                .Include(x => x.PriceRange)
                .Include(x => x.VehicleType)
                .SingleOrDefault();
        }
    }
}
