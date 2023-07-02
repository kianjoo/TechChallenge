﻿// <auto-generated />
using System;
using FlightPlanWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightPlanWeb.Migrations
{
    [DbContext(typeof(FlightPlanDbContext))]
    partial class FlightPlanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightPlanWeb.Models.Aircraft", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("aircraftAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aircraftApproachCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aircraftColorAndMarking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aircraftRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aircraftType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("communicationid")
                        .HasColumnType("int");

                    b.Property<int?>("navigationid")
                        .HasColumnType("int");

                    b.Property<int>("numberOfAircraft")
                        .HasColumnType("int");

                    b.Property<string>("otherSurveillanceCapabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("standardCapabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surveillanceCapabilitiesCodesJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("survivalid")
                        .HasColumnType("int");

                    b.Property<string>("wakeTurbulence")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("communicationid");

                    b.HasIndex("navigationid");

                    b.HasIndex("survivalid");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.ApacAircraftTrack", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("actualSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("flightLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("positionTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("positionid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("positionid");

                    b.ToTable("ApacAircraftTrack");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.ApacArrival", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("calculatedLandingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("estimatedLandingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("ApacArrival");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.ApacDeparture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("actualOffBlockTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("calculatedTakeOffTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("targetOffBlockTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("targetStartupApprovalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("targetedTakeOffTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("ApacDeparture");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.ApacTrajElements", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.HasKey("id");

                    b.ToTable("ApacTrajElements");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Arrival", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("actualTimeOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<string>("airportSlotIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("alternativeAerodromeJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("apacArrivalid")
                        .HasColumnType("int");

                    b.Property<string>("arrivalAerodrome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("arrivalRunwayDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destinationAerodrome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("apacArrivalid");

                    b.ToTable("Arrival");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.BoundaryCrossing", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("clearLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crossingPointid")
                        .HasColumnType("int");

                    b.Property<string>("crossingTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("supplementaryCrossingLevel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("crossingPointid");

                    b.ToTable("BoundaryCrossing");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Communication", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("communicationCapabilityCodeJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dataLinkCapabilityCodeJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("otherCommunicationCapabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("otherDataLinkCapabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("selectiveCallingCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Communication");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.CrossingPoint", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("bearing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("designatedPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lat")
                        .HasColumnType("int");

                    b.Property<int>("lon")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("CrossingPoint");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Departure", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("actualTimeOfDeparture")
                        .HasColumnType("datetime2");

                    b.Property<string>("airportSlotIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("apacDepartureid")
                        .HasColumnType("int");

                    b.Property<string>("dateOfFlight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departureAerodrome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departureAlternativeAerodrome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estimatedOffBLockTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("runwayDirection")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("apacDepartureid");

                    b.ToTable("Departure");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Dinghies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("carried")
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("covered")
                        .HasColumnType("bit");

                    b.Property<int>("totalCapacity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Dinghies");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.EnRoute", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("alternativeEnRouteAerodrome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("boundaryCrossingid")
                        .HasColumnType("int");

                    b.Property<string>("currentModeACode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("boundaryCrossingid");

                    b.ToTable("EnRoute");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.FiledRoute", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.HasKey("id");

                    b.ToTable("FiledRoute");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.FiledRouteElement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("FiledRouteid")
                        .HasColumnType("int");

                    b.Property<string>("airway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("airwayType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("changeLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("changeOfFlightRule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("changeSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("positionid")
                        .HasColumnType("int");

                    b.Property<int>("seqNum")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FiledRouteid");

                    b.HasIndex("positionid");

                    b.ToTable("FiledRouteElement");

                    b.HasAnnotation("Relational:JsonPropertyName", "RouteElement");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.FlightPlan", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("Relational:JsonPropertyName", "_id");

                    b.Property<string>("aircraftIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("aircraftOperating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("aircraftid")
                        .HasColumnType("int");

                    b.Property<int?>("apacAircraftTrackid")
                        .HasColumnType("int");

                    b.Property<int?>("apacTrajElementsid")
                        .HasColumnType("int");

                    b.Property<int?>("arrivalid")
                        .HasColumnType("int");

                    b.Property<int?>("departureid")
                        .HasColumnType("int");

                    b.Property<int?>("enRouteid")
                        .HasColumnType("int");

                    b.Property<int?>("filedRouteid")
                        .HasColumnType("int");

                    b.Property<string>("flightPlanOriginator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("flightType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gufi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gufiOriginator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdatedTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("messageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specialHandlingReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("supplementaryid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("aircraftid");

                    b.HasIndex("apacAircraftTrackid");

                    b.HasIndex("apacTrajElementsid");

                    b.HasIndex("arrivalid");

                    b.HasIndex("departureid");

                    b.HasIndex("enRouteid");

                    b.HasIndex("filedRouteid");

                    b.HasIndex("supplementaryid");

                    b.ToTable("FlightPlan");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Navigation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("navigationCapabilitiesCodeJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("otherNavigationCapabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("performanceBasedCodeJson")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Navigation");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Position", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("bearing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("designatedPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lat")
                        .HasColumnType("int");

                    b.Property<int>("lon")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.RoutePoint", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("bearing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("designatedPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lat")
                        .HasColumnType("int");

                    b.Property<int>("lon")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("RoutePoint");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Supplementary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("fuelEnduranceTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameOfPilot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("totalNumberOfPeople")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Supplementary");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Survival", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("dinghiesid")
                        .HasColumnType("int");

                    b.Property<string>("emergencyRadioCapability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lifeJacket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("otherSurvivalEquipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("survivalEquipment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("dinghiesid");

                    b.ToTable("Survival");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.TrajRouteElement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("ApacTrajElementsid")
                        .HasColumnType("int");

                    b.Property<DateTime>("actualTimeOver")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("calculatedTimeOver")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("estimatedTimeOver")
                        .HasColumnType("datetime2");

                    b.Property<string>("level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("routePointid")
                        .HasColumnType("int");

                    b.Property<int>("seqNum")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ApacTrajElementsid");

                    b.HasIndex("routePointid");

                    b.ToTable("TrajRouteElement");

                    b.HasAnnotation("Relational:JsonPropertyName", "RouteElement");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Aircraft", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.Communication", "communication")
                        .WithMany()
                        .HasForeignKey("communicationid");

                    b.HasOne("FlightPlanWeb.Models.Navigation", "navigation")
                        .WithMany()
                        .HasForeignKey("navigationid");

                    b.HasOne("FlightPlanWeb.Models.Survival", "survival")
                        .WithMany()
                        .HasForeignKey("survivalid");

                    b.Navigation("communication");

                    b.Navigation("navigation");

                    b.Navigation("survival");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.ApacAircraftTrack", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.Position", "position")
                        .WithMany()
                        .HasForeignKey("positionid");

                    b.Navigation("position");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Arrival", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.ApacArrival", "apacArrival")
                        .WithMany()
                        .HasForeignKey("apacArrivalid");

                    b.Navigation("apacArrival");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.BoundaryCrossing", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.CrossingPoint", "crossingPoint")
                        .WithMany()
                        .HasForeignKey("crossingPointid");

                    b.Navigation("crossingPoint");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Departure", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.ApacDeparture", "apacDeparture")
                        .WithMany()
                        .HasForeignKey("apacDepartureid");

                    b.Navigation("apacDeparture");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.EnRoute", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.BoundaryCrossing", "boundaryCrossing")
                        .WithMany()
                        .HasForeignKey("boundaryCrossingid");

                    b.Navigation("boundaryCrossing");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.FiledRouteElement", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.FiledRoute", null)
                        .WithMany("routeElement")
                        .HasForeignKey("FiledRouteid");

                    b.HasOne("FlightPlanWeb.Models.Position", "position")
                        .WithMany()
                        .HasForeignKey("positionid");

                    b.Navigation("position");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.FlightPlan", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.Aircraft", "aircraft")
                        .WithMany()
                        .HasForeignKey("aircraftid");

                    b.HasOne("FlightPlanWeb.Models.ApacAircraftTrack", "apacAircraftTrack")
                        .WithMany()
                        .HasForeignKey("apacAircraftTrackid");

                    b.HasOne("FlightPlanWeb.Models.ApacTrajElements", "apacTrajElements")
                        .WithMany()
                        .HasForeignKey("apacTrajElementsid");

                    b.HasOne("FlightPlanWeb.Models.Arrival", "arrival")
                        .WithMany()
                        .HasForeignKey("arrivalid");

                    b.HasOne("FlightPlanWeb.Models.Departure", "departure")
                        .WithMany()
                        .HasForeignKey("departureid");

                    b.HasOne("FlightPlanWeb.Models.EnRoute", "enRoute")
                        .WithMany()
                        .HasForeignKey("enRouteid");

                    b.HasOne("FlightPlanWeb.Models.FiledRoute", "filedRoute")
                        .WithMany()
                        .HasForeignKey("filedRouteid");

                    b.HasOne("FlightPlanWeb.Models.Supplementary", "supplementary")
                        .WithMany()
                        .HasForeignKey("supplementaryid");

                    b.Navigation("aircraft");

                    b.Navigation("apacAircraftTrack");

                    b.Navigation("apacTrajElements");

                    b.Navigation("arrival");

                    b.Navigation("departure");

                    b.Navigation("enRoute");

                    b.Navigation("filedRoute");

                    b.Navigation("supplementary");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.Survival", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.Dinghies", "dinghies")
                        .WithMany()
                        .HasForeignKey("dinghiesid");

                    b.Navigation("dinghies");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.TrajRouteElement", b =>
                {
                    b.HasOne("FlightPlanWeb.Models.ApacTrajElements", null)
                        .WithMany("routeElement")
                        .HasForeignKey("ApacTrajElementsid");

                    b.HasOne("FlightPlanWeb.Models.RoutePoint", "routePoint")
                        .WithMany()
                        .HasForeignKey("routePointid");

                    b.Navigation("routePoint");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.ApacTrajElements", b =>
                {
                    b.Navigation("routeElement");
                });

            modelBuilder.Entity("FlightPlanWeb.Models.FiledRoute", b =>
                {
                    b.Navigation("routeElement");
                });
#pragma warning restore 612, 618
        }
    }
}
