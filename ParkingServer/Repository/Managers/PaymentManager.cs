﻿using ParkingServer.Repository.Entities;
using ParkingServer.Repository.Managers.Interfaces;
using ParkingServer.Repository.RepositoryBaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository.Managers
{
    public class PaymentManager : RepositoryBase<Payment>, IPaymentManager
    {
        public PaymentManager(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
