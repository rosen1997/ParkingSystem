using AutoMapper;
using ParkingServer.Models.EntityModels;
using ParkingServer.Repository.Entities;
using ParkingServer.Repository.Services.Interfaces;
using ParkingServer.Repository.UnitOfWorkFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Services
{
    public class ParkingStatusService : IParkingStatusService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ParkingStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<ParkingStatusModel> GetAllParkingStatus()
        {
            var parkingStatuses = unitOfWork.ParkingStatusManager.GetAll();

            return mapper.Map<IEnumerable<ParkingStatusModel>>(parkingStatuses);
        }

        public IEnumerable<PaymentModel> GetAllPayments()
        {
            var payments = unitOfWork.PaymentManager.GetAll();

            return mapper.Map<IEnumerable<PaymentModel>>(payments);
        }

        public PaymentModel GetCalculatedPayment(ParkingStatusModel parkingStatusModel)
        {
            var lastEntry = unitOfWork.ParkingStatusManager.GetByLicensePlateLastEntry(parkingStatusModel.LicensePlate);
            PaymentModel paymentModel = CalculatePayment(lastEntry.TimeOfArrival, parkingStatusModel.TimeOfLeave.GetValueOrDefault(), lastEntry.PriceRange.Price);

            return paymentModel;

        }

        private static PaymentModel CalculatePayment(DateTime entry, DateTime leave, double amountHour)
        {
            var totalHours = Math.Ceiling(((leave - entry).TotalHours));
            var price = totalHours * amountHour;

            var paymentModel = new PaymentModel { PaymentDate = leave, PaymentAmount = price };
            return paymentModel;
        }

        public IEnumerable<ParkingStatusModel> GetParkingStatusByEntryDate(DateTime entryDate)
        {
            var parkings = unitOfWork.ParkingStatusManager.GetByEntryDate(entryDate);

            return mapper.Map<IEnumerable<ParkingStatusModel>>(parkings);
        }

        public IEnumerable<ParkingStatusModel> GetParkingStatusByLicensePlate(string licensePlate)
        {
            var parkings = unitOfWork.ParkingStatusManager.GetByLicensePlate(licensePlate);

            return mapper.Map<IEnumerable<ParkingStatusModel>>(parkings);
        }

        public IEnumerable<PaymentModel> GetPaymentsByDate(DateTime paymentDate)
        {
            var payments = unitOfWork.PaymentManager.GetAllByDate(paymentDate);

            return mapper.Map<IEnumerable<PaymentModel>>(payments);
        }

        public IEnumerable<PaymentModel> GetPaymentsByLicensePlate(string licensePlate)
        {
            var payments = unitOfWork.PaymentManager.GetAllByLicensePlate(licensePlate);

            return mapper.Map<IEnumerable<PaymentModel>>(payments);
        }

        public PaymentModel Leave(ParkingStatusModel parkingStatusModel)
        {
            var lastEntry = unitOfWork.ParkingStatusManager.GetByLicensePlateLastEntry(parkingStatusModel.LicensePlate);
            lastEntry.TimeOfLeave = parkingStatusModel.TimeOfLeave.GetValueOrDefault();

            //TODO: payment may be present in parking status model  
            //PaymentModel payment = CalculatePayment(lastEntry.TimeOfArrival, parkingStatusModel.TimeOfLeave.GetValueOrDefault(), lastEntry.PriceRange.Price);

            Payment paymentEntity = mapper.Map<Payment>(parkingStatusModel.Payment);
            lastEntry.Payment = paymentEntity;

            try
            {
                unitOfWork.ParkingStatusManager.Update(lastEntry);
                unitOfWork.SaveChanges();

                return mapper.Map<PaymentModel>(lastEntry.Payment);
            }
            catch
            {
                throw;
            }
        }

        public ParkingStatusModel VehicleEntry(ParkingStatusModel parkingStatusModel)
        {
            var parkingStatusEntity = mapper.Map<ParkingStatus>(parkingStatusModel);

            var registeredVehicle = unitOfWork.RegisteredVehicleManager.GetByLicensePlate(parkingStatusEntity.LicensePlate);
            if (registeredVehicle != null)
            {
                parkingStatusEntity.PriceRangeId = registeredVehicle.PriceRangeId;
                parkingStatusEntity.RegisteredVehicleId = registeredVehicle.Id;
            }
            else
            {
                var highestPrice = unitOfWork.PriceRangeManager.GetAll().Aggregate((i1, i2) => i1.Price > i2.Price ? i1 : i2);
                parkingStatusEntity.PriceRangeId = highestPrice.Id;
            }

            try
            {
                unitOfWork.ParkingStatusManager.Create(parkingStatusEntity);
                unitOfWork.SaveChanges();

                return mapper.Map<ParkingStatusModel>(parkingStatusEntity);
            }
            catch
            {
                throw;
            }
        }
    }
}
