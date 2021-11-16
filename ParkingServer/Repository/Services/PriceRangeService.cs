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
    public class PriceRangeService : IPriceRangeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PriceRangeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PriceRangeModel AddPriceRange(PriceRangeModel priceRange)
        {
            var priceRangeEntity = mapper.Map<PriceRange>(priceRange);

            try
            {
                unitOfWork.PriceRangeManager.Create(priceRangeEntity);
                unitOfWork.SaveChanges();
                return mapper.Map<PriceRangeModel>(priceRangeEntity);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<PriceRangeModel> GetAll()
        {
            var priceRanges = unitOfWork.PriceRangeManager.GetAll();
            var priceRangesModel = mapper.Map<IEnumerable<PriceRangeModel>>(priceRanges);

            return priceRangesModel;
        }
    }
}
