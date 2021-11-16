using Microsoft.EntityFrameworkCore;
using ParkingServer.Repository.Entities;
using ParkingServer.Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<PriceRange> PriceRanges { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<RegisteredVehicle> RegisteredVehicles { get; set; }
        public DbSet<ParkingData> ParkingsData { get; set; }
        public DbSet<ParkingStatus> ParkingDatas { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region PriceRanges
            modelBuilder.Entity<PriceRange>()
                .HasData(PriceRangesSeed.Seed());
            #endregion

            #region VehicleTypes
            modelBuilder.Entity<VehicleType>()
                .HasData(VehicleTypesSeed.Seed());
            #endregion

            #region RegisteredVehicles
            modelBuilder.Entity<RegisteredVehicle>()
                .HasIndex(x => x.LicensePlate).IsUnique();
            #endregion

            #region ParkingsData
            modelBuilder.Entity<ParkingData>()
                .HasData(ParkingsDataSeed.Seed());
            #endregion

            #region ParkingStatus
            modelBuilder.Entity<ParkingStatus>()
                .HasOne(x => x.RegisteredVehicle)
                .WithMany(x => x.ParkingStatuses)
                .OnDelete(DeleteBehavior.ClientSetNull);
            #endregion

            #region Payments
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.ParkingStatus)
                .WithOne(x => x.Payment);
            #endregion
        }
    }
}
