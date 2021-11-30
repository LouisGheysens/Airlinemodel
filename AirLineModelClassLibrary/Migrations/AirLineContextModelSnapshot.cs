﻿// <auto-generated />
using System;
using AirLineModelClassLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirLineModelClassLibrary.Migrations
{
    [DbContext(typeof(AirLineContext))]
    partial class AirLineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("AirLines");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.CabinMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("WerkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WerkId");

                    b.ToTable("CabinMembers");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Flight", b =>
                {
                    b.Property<string>("FlightNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("Arrival")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("CopilotId")
                        .HasColumnType("int");

                    b.Property<string>("Departure")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("PassengerInfoId")
                        .HasColumnType("int");

                    b.Property<int>("PilotId")
                        .HasColumnType("int");

                    b.HasKey("FlightNumber");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("CopilotId");

                    b.HasIndex("PassengerInfoId")
                        .IsUnique()
                        .HasFilter("[PassengerInfoId] IS NOT NULL");

                    b.HasIndex("PilotId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.PassengerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessSeatsOccupied")
                        .HasColumnType("int");

                    b.Property<int>("EconomySeatsOccupied")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PassengerInfos");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("WerkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WerkId");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("CabinMemberFlight", b =>
                {
                    b.Property<int>("CabinMembersId")
                        .HasColumnType("int");

                    b.Property<string>("VluchtenFlightNumber")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CabinMembersId", "VluchtenFlightNumber");

                    b.HasIndex("VluchtenFlightNumber");

                    b.ToTable("CabinMemberFlight");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.CabinMember", b =>
                {
                    b.HasOne("AirLineModelClassLibrary.Models.Airline", "Werk")
                        .WithMany("CabinMembers")
                        .HasForeignKey("WerkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Werk");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Flight", b =>
                {
                    b.HasOne("AirLineModelClassLibrary.Models.Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirLineModelClassLibrary.Models.Pilot", "CoPiloot")
                        .WithMany("VluchtenCoPiloot")
                        .HasForeignKey("CopilotId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AirLineModelClassLibrary.Models.PassengerInfo", "PassengerInfo")
                        .WithOne("Flight")
                        .HasForeignKey("AirLineModelClassLibrary.Models.Flight", "PassengerInfoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AirLineModelClassLibrary.Models.Pilot", "Piloot")
                        .WithMany("VluchtenPiloot")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("CoPiloot");

                    b.Navigation("PassengerInfo");

                    b.Navigation("Piloot");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Pilot", b =>
                {
                    b.HasOne("AirLineModelClassLibrary.Models.Airline", "Werk")
                        .WithMany("Piloten")
                        .HasForeignKey("WerkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Werk");
                });

            modelBuilder.Entity("CabinMemberFlight", b =>
                {
                    b.HasOne("AirLineModelClassLibrary.Models.CabinMember", null)
                        .WithMany()
                        .HasForeignKey("CabinMembersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirLineModelClassLibrary.Models.Flight", null)
                        .WithMany()
                        .HasForeignKey("VluchtenFlightNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Airline", b =>
                {
                    b.Navigation("CabinMembers");

                    b.Navigation("Piloten");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Airplane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.PassengerInfo", b =>
                {
                    b.Navigation("Flight")
                        .IsRequired();
                });

            modelBuilder.Entity("AirLineModelClassLibrary.Models.Pilot", b =>
                {
                    b.Navigation("VluchtenCoPiloot");

                    b.Navigation("VluchtenPiloot");
                });
#pragma warning restore 612, 618
        }
    }
}
