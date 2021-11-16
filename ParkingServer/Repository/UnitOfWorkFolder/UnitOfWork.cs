﻿using ParkingServer.Repository.Managers;
using ParkingServer.Repository.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.UnitOfWorkFolder
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext repositoryContext;
        private bool disposedValue;

        public IParkingDataManager ParkingDataManager { get; }

        public IParkingStatusManager ParkingStatusManager { get; }

        public IPaymentManager PaymentManager { get; }

        public IPriceRangeManager PriceRangeManager { get; }

        public IRegisteredVehicleManager RegisteredVehicleManager { get; }

        public IVehicleTypeManager VehicleTypeManager { get; }

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            ParkingDataManager = new ParkingDataManager(repositoryContext);
            ParkingStatusManager = new ParkingStatusManager(repositoryContext);
            PaymentManager = new PaymentManager(repositoryContext);
            PriceRangeManager = new PriceRangeManager(repositoryContext);
            RegisteredVehicleManager = new RegisteredVehicleManager(repositoryContext);
            VehicleTypeManager = new VehicleTypeManager(repositoryContext);
        }

        public void RevertChanges()
        {
            foreach (var entry in repositoryContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:
                    case Microsoft.EntityFrameworkCore.EntityState.Detached:
                        entry.Reload();
                        break;
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        break;
                    default: break;
                }
            }
        }
        public void SaveChanges()
        {
            repositoryContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            repositoryContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            repositoryContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            repositoryContext.Database.RollbackTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    repositoryContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
