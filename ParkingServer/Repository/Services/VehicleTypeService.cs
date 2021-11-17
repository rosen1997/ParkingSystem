using AutoMapper;
using ParkingServer.Models;
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
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public VehicleTypeModel AddVehicleType(VehicleTypeModel vehicleTypeModel)
        {
            var vehicleTypeEntity = mapper.Map<VehicleType>(vehicleTypeModel);

            try
            {
                unitOfWork.VehicleTypeManager.Create(vehicleTypeEntity);
                unitOfWork.SaveChanges();
                return mapper.Map<VehicleTypeModel>(vehicleTypeEntity);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<VehicleTypeModel> GetAll()
        {
            var vehicleTypes = unitOfWork.VehicleTypeManager.GetAll();
            return mapper.Map<IEnumerable<VehicleTypeModel>>(vehicleTypes);
        }
    }
}
