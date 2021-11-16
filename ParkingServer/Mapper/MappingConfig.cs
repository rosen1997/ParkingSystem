using AutoMapper;
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
    }
}
