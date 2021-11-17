﻿using ParkingServer.Repository.Entities;
using ParkingServer.Repository.RepositoryBaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Managers.Interfaces
{
    public interface IPaymentManager : IRepositoryBase<Payment>
    {
        public IEnumerable<Payment> GetAllByDate(DateTime dateTime);
        public IEnumerable<Payment> GetAllByLicensePlate(string licensePlate);
    }
}
