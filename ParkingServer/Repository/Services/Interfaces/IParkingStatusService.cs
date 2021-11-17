using ParkingServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Services.Interfaces
{
    public interface IParkingStatusService
    {
        public IEnumerable<ParkingStatusModel> GetAllParkingStatus();
        public IEnumerable<PaymentModel> GetAllPayments();
        public IEnumerable<ParkingStatusModel> GetParkingStatusByLicensePlate(string licensePlate);
        public IEnumerable<ParkingStatusModel> GetParkingStatusByEntryDate(DateTime entryDate);
        public IEnumerable<PaymentModel> GetPaymentsByDate(DateTime paymentDate);
        public IEnumerable<PaymentModel> GetPaymentsByLicensePlate(string licensePlate);
        public ParkingStatusModel VehicleEntry(ParkingStatusModel parkingStatusModel);
        public PaymentModel GetCalculatedPayment(ParkingStatusModel parkingStatusModel);
        public PaymentModel Leave(ParkingStatusModel parkingStatusModel);

    }
}
