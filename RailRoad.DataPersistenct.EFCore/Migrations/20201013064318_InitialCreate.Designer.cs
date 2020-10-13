﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailRoad.DataPersistenct.EFCore.Repositories;

namespace RailRoad.DataPersistenct.EFCore.Migrations
{
    [DbContext(typeof(SiteTripRepository))]
    [Migration("20201013064318_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RailRoad.DataPersistence.Entities.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SITE_ID")
                        .HasColumnType("int");

                    b.Property<int>("DefaultTripChargesId")
                        .HasColumnName("TRIPCHARGES_ID")
                        .HasColumnType("int");

                    b.Property<double>("DefaultTruckCapacity")
                        .HasColumnName("DEF_TRUCK_CAPACITY")
                        .HasColumnType("double");

                    b.Property<int>("Distance")
                        .HasColumnName("DISTANCE")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DefaultTripChargesId");

                    b.ToTable("SITE");
                });

            modelBuilder.Entity("RailRoad.DataPersistence.Entities.TripCharges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TRIPCHARGES_ID")
                        .HasColumnType("int");

                    b.Property<double>("ExcavationCharge")
                        .HasColumnName("EXCAVATION_CHARGE")
                        .HasColumnType("double");

                    b.Property<double>("LntBasicCharge")
                        .HasColumnName("LNT_BASIC_CHARGE")
                        .HasColumnType("double");

                    b.Property<double>("LntLeadingCharge")
                        .HasColumnName("LNT_LEADING_CHARGE")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("TRIPCHARGES");
                });

            modelBuilder.Entity("RailRoad.DataPersistence.Entities.TripsRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TRIPSRECORD_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("TRIPS_DATE")
                        .HasColumnType("datetime");

                    b.Property<double>("DieselPrice")
                        .HasColumnName("DIESEL_PRICE")
                        .HasColumnType("double");

                    b.Property<double>("DieselQuantity")
                        .HasColumnName("DIESEL_QUANTITY")
                        .HasColumnType("double");

                    b.Property<int>("SiteId")
                        .HasColumnName("SITE_ID")
                        .HasColumnType("int");

                    b.Property<int?>("TripChargesId")
                        .HasColumnName("TRIPCHARGES")
                        .HasColumnType("int");

                    b.Property<int>("TripsCount")
                        .HasColumnName("TRIPS_COUNT")
                        .HasColumnType("int");

                    b.Property<double>("TruckCapacity")
                        .HasColumnName("TRUCK_CAPACITY")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("TripChargesId");

                    b.ToTable("TRIPSRECORD");
                });

            modelBuilder.Entity("RailRoad.DataPersistence.Entities.Site", b =>
                {
                    b.HasOne("RailRoad.DataPersistence.Entities.TripCharges", "DefaultTripCharges")
                        .WithMany()
                        .HasForeignKey("DefaultTripChargesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RailRoad.DataPersistence.Entities.TripsRecord", b =>
                {
                    b.HasOne("RailRoad.DataPersistence.Entities.Site", "Site")
                        .WithMany("TripsRecords")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailRoad.DataPersistence.Entities.TripCharges", "TripCharges")
                        .WithMany()
                        .HasForeignKey("TripChargesId");
                });
#pragma warning restore 612, 618
        }
    }
}
