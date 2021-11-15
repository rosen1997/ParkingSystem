using ParkingServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Seeds
{
    public static class ParkingsDataSeed
    {
        public static ParkingData[] Seed()
        {
            return new ParkingData[]
            {
                new ParkingData{Id=1, Name="Rosen's Parking", Description="My super duper cool parking.", AllSpaces=100, FreeSpacesLeft=100 }
            };
        }
    }
}
