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
    public class ParkingDataService : IParkingDataService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ParkingDataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ParkingDataModel Get()
        {
            var parkingData = unitOfWork.ParkingDataManager.GetAll().First();
            return mapper.Map<ParkingDataModel>(parkingData);
        }

        public ParkingDataModel UpdateData(ParkingDataModel parkingDataModel)
        {
            var parkingDataDb = Get();

            parkingDataDb.Description = parkingDataModel.Description;
            parkingDataDb.Name = parkingDataModel.Name;

            try
            {
                var parkingDataEntity = mapper.Map<ParkingData>(parkingDataDb);
                unitOfWork.ParkingDataManager.Update(parkingDataEntity);
                unitOfWork.SaveChanges();

                return mapper.Map<ParkingDataModel>(parkingDataEntity);
            }
            catch
            {
                throw;
            }
        }
    }
}
