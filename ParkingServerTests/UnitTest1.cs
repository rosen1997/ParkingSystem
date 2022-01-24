using AutoMapper;
using NUnit.Framework;
using ParkingServer.Models.EntityModels;
using ParkingServer.Repository.Services;
using ParkingServer.Repository.Services.Interfaces;
using ParkingServer.Repository.UnitOfWorkFolder;
using System;
using System.Reflection;

namespace ParkingServerTests
{
    public class ParkingPaymentCalculationTests
    {
        private ParkingStatusService parkingStatusService;

        [SetUp]
        public void Setup()
        {
            this.parkingStatusService = new ParkingStatusService(null, null);
        }

        [Test]
        public void Test1()
        {
            var method = this.parkingStatusService.GetType().GetMethod("CalculatePayment", BindingFlags.NonPublic | BindingFlags.Static);

            object[] data = new object[3] { DateTime.UtcNow, DateTime.UtcNow.AddHours(2).AddMinutes(5), 3 };
            var calculation = method.Invoke(null, data) as PaymentModel;

            Assert.AreEqual(9, calculation.PaymentAmount);
        }

        [Test]
        public void Test2()
        {
            var method = this.parkingStatusService.GetType().GetMethod("CalculatePayment", BindingFlags.NonPublic | BindingFlags.Static);

            object[] data = new object[3] { DateTime.UtcNow, DateTime.UtcNow.AddHours(3).AddMinutes(25), 3 };
            var calculation = method.Invoke(null, data) as PaymentModel;

            Assert.AreEqual(12, calculation.PaymentAmount);
        }
    }
}