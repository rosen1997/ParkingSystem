using ParkingServer.Repository.Entities;
using ParkingServer.Repository.RepositoryBaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Managers.Interfaces
{
    public interface IParkingStatusManager : IRepositoryBase<ParkingStatus>
    {
        public IEnumerable<ParkingStatus> GetByEntryDate(DateTime dateTime);
        public IEnumerable<ParkingStatus> GetByLicensePlate(string licensePlate);
        public ParkingStatus GetByLicensePlateLastEntry(string licensePlate);
    }
}
