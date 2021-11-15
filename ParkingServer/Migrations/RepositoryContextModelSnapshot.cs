﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingServer.Repository;

namespace ParkingServer.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingServer.Repository.Entities.PriceRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PriceRange");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Price = 0.5
                        },
                        new
                        {
                            Id = 3,
                            Price = 1.0
                        });
                });

            modelBuilder.Entity("ParkingServer.Repository.Entities.RegisteredVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("PriceRangeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.HasIndex("PriceRangeId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("RegisteredVehicles");
                });

            modelBuilder.Entity("ParkingServer.Repository.Entities.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Ambulance"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Police Car"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Fire Truck"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Ambulance"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Company Car"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Paid Subscription"
                        });
                });

            modelBuilder.Entity("ParkingServer.Repository.Entities.RegisteredVehicle", b =>
                {
                    b.HasOne("ParkingServer.Repository.Entities.PriceRange", "PriceRange")
                        .WithMany("RegisteredVehicles")
                        .HasForeignKey("PriceRangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingServer.Repository.Entities.VehicleType", "VehicleType")
                        .WithMany("RegisteredVehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}