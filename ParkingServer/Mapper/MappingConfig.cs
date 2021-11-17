using AutoMapper;
using ParkingServer.Models;
using ParkingServer.Models.EntityModels;
using ParkingServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            PriceRangeMap();
            PriceRangeModelMap();
            VehicleTypeMap();
            VehicleTypeModelMap();
            ParkingDataMap();
            ParkingDataModelMap();
        }

        private void PriceRangeMap()
        {
            CreateMap<PriceRange, PriceRangeModel>()
                ;
        }

        private void PriceRangeModelMap()
        {
            CreateMap<PriceRangeModel, PriceRange>()
                ;
        }

        private void VehicleTypeMap()
        {
            CreateMap<VehicleType, VehicleTypeModel>()
                ;
        }

        private void VehicleTypeModelMap()
        {
            CreateMap<VehicleTypeModel, VehicleType>()
                ;
        }

        private void ParkingDataMap()
        {
            CreateMap<ParkingData, ParkingDataModel>()
                ;
        }

        private void ParkingDataModelMap()
        {
            CreateMap<ParkingDataModel, ParkingData>()
                ;
        }
    }
}
