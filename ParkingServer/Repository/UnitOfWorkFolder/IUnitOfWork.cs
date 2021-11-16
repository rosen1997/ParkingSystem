using ParkingServer.Repository.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.UnitOfWorkFolder
{
    public interface IUnitOfWork : IDisposable
    {
        IParkingDataManager ParkingDataManager { get; }
        IParkingStatusManager ParkingStatusManager { get; }
        IPaymentManager PaymentManager { get; }
        IPriceRangeManager PriceRangeManager { get; }
        IRegisteredVehicleManager RegisteredVehicleManager { get; }
        IVehicleTypeManager VehicleTypeManager { get; }

        void RevertChanges();
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
