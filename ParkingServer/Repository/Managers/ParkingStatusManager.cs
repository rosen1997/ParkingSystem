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
    public class ParkingStatusManager : RepositoryBase<ParkingStatus>, IParkingStatusManager
    {
        public ParkingStatusManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<ParkingStatus> GetByEntryDate(DateTime dateTime)
        {
            return RepositoryContext.ParkingStatuses.Where(x => x.TimeOfArrival.Equals(dateTime));
        }

        public IEnumerable<ParkingStatus> GetByLicensePlate(string licensePlate)
        {
            return RepositoryContext.ParkingStatuses.Where(x => x.LicensePlate.Equals(licensePlate));
        }

        public ParkingStatus GetByLicensePlateLastEntry(string licensePlate)
        {
            return RepositoryContext.ParkingStatuses.Where(x => x.LicensePlate.Equals(licensePlate) && x.TimeOfLeave == null)
                .Include(x => x.PriceRange)
                .SingleOrDefault();
        }
    }
}
