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
    public class PaymentManager : RepositoryBase<Payment>, IPaymentManager
    {
        public PaymentManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Payment> GetAllByDate(DateTime dateTime)
        {
            return RepositoryContext.Payments.Where(x => x.PaymentDate.Equals(dateTime));
        }

        public IEnumerable<Payment> GetAllByLicensePlate(string licensePlate)
        {
            return RepositoryContext.Payments
                .Include(x => x.ParkingStatus)
                .Where(x => x.ParkingStatus.LicensePlate.Equals(licensePlate));
        }
    }
}
