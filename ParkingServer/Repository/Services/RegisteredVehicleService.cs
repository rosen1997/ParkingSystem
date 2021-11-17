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
    public class RegisteredVehicleService : IRegisteredVehicleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RegisteredVehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<RegisteredVehicleModel> GetAll()
        {
            var registeredVehicles = unitOfWork.RegisteredVehicleManager.GetAllWithRelations();

            return mapper.Map<IEnumerable<RegisteredVehicleModel>>(registeredVehicles);
        }

        public RegisteredVehicleModel GetByLicensePlate(string licensePlate)
        {
            var registeredVehicle = unitOfWork.RegisteredVehicleManager.GetByLicensePlate(licensePlate);

            return mapper.Map<RegisteredVehicleModel>(registeredVehicle);
        }

        public RegisteredVehicleModel RegisterVehicle(RegisteredVehicleModel registeredVehicleModel)
        {
            var registeredVehicleEntity = mapper.Map<RegisteredVehicle>(registeredVehicleModel);

            try
            {
                unitOfWork.RegisteredVehicleManager.Create(registeredVehicleEntity);
                unitOfWork.SaveChanges();

                return mapper.Map<RegisteredVehicleModel>(registeredVehicleEntity);
            }
            catch
            {
                throw;
            }
        }

        public void RemoveVehicle(RegisteredVehicleModel registeredVehicleModel)
        {
            var registeredVehicle = mapper.Map<RegisteredVehicle>(registeredVehicleModel);

            try
            {
                unitOfWork.RegisteredVehicleManager.Delete(registeredVehicle);
                unitOfWork.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public RegisteredVehicleModel UpdateRegisteredVehicleData(RegisteredVehicleModel registeredVehicleModel)
        {
            var registeredVehicle = mapper.Map<RegisteredVehicle>(registeredVehicleModel);

            try
            {
                unitOfWork.RegisteredVehicleManager.Update(registeredVehicle);
                unitOfWork.SaveChanges();

                return mapper.Map<RegisteredVehicleModel>(registeredVehicle);
            }
            catch
            {
                throw;
            }

        }
    }
}
