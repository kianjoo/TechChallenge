using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightPlanWeb.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApacArrival",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calculatedLandingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estimatedLandingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApacArrival", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApacDeparture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actualOffBlockTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calculatedTakeOffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    targetOffBlockTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    targetStartupApprovalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    targetedTakeOffTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApacDeparture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApacTrajElements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApacTrajElements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Communication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selectiveCallingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherCommunicationCapabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherDataLinkCapabilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CrossingPoint",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lat = table.Column<int>(type: "int", nullable: false),
                    lon = table.Column<int>(type: "int", nullable: false),
                    designatedPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bearing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossingPoint", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dinghies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carried = table.Column<int>(type: "int", nullable: false),
                    totalCapacity = table.Column<int>(type: "int", nullable: false),
                    covered = table.Column<bool>(type: "bit", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinghies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FiledRoute",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiledRoute", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    otherNavigationCapabilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lat = table.Column<int>(type: "int", nullable: false),
                    lon = table.Column<int>(type: "int", nullable: false),
                    designatedPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bearing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoutePoint",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lat = table.Column<int>(type: "int", nullable: false),
                    lon = table.Column<int>(type: "int", nullable: false),
                    designatedPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bearing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePoint", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Supplementary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fuelEnduranceTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalNumberOfPeople = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameOfPilot = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplementary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Arrival",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destinationAerodrome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airportSlotIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalRunwayDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalAerodrome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actualTimeOfArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    apacArrivalid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrival", x => x.id);
                    table.ForeignKey(
                        name: "FK_Arrival_ApacArrival_apacArrivalid",
                        column: x => x.apacArrivalid,
                        principalTable: "ApacArrival",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Departure",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apacDepartureid = table.Column<int>(type: "int", nullable: true),
                    departureAerodrome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfFlight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estimatedOffBLockTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actualTimeOfDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    runwayDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airportSlotIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureAlternativeAerodrome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departure", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departure_ApacDeparture_apacDepartureid",
                        column: x => x.apacDepartureid,
                        principalTable: "ApacDeparture",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CommunicationCapabilityCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    communicationCapabilityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Communicationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationCapabilityCode", x => x.id);
                    table.ForeignKey(
                        name: "FK_CommunicationCapabilityCode_Communication_Communicationid",
                        column: x => x.Communicationid,
                        principalTable: "Communication",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DataLinkCapabilityCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataLinkCapabilityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Communicationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLinkCapabilityCode", x => x.id);
                    table.ForeignKey(
                        name: "FK_DataLinkCapabilityCode_Communication_Communicationid",
                        column: x => x.Communicationid,
                        principalTable: "Communication",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BoundaryCrossing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crossingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clearLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    supplementaryCrossingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crossingPointid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoundaryCrossing", x => x.id);
                    table.ForeignKey(
                        name: "FK_BoundaryCrossing_CrossingPoint_crossingPointid",
                        column: x => x.crossingPointid,
                        principalTable: "CrossingPoint",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Survival",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survivalEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherSurvivalEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emergencyRadioCapability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lifeJacket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dinghiesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survival", x => x.id);
                    table.ForeignKey(
                        name: "FK_Survival_Dinghies_dinghiesid",
                        column: x => x.dinghiesid,
                        principalTable: "Dinghies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NavigationCapabilitiesCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    navigationCapabilitiesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Navigationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationCapabilitiesCode", x => x.id);
                    table.ForeignKey(
                        name: "FK_NavigationCapabilitiesCode_Navigation_Navigationid",
                        column: x => x.Navigationid,
                        principalTable: "Navigation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PerformanceBasedCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    performanceBasedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Navigationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceBasedCode", x => x.id);
                    table.ForeignKey(
                        name: "FK_PerformanceBasedCode_Navigation_Navigationid",
                        column: x => x.Navigationid,
                        principalTable: "Navigation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ApacAircraftTrack",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actualSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flightLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    positionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    positionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApacAircraftTrack", x => x.id);
                    table.ForeignKey(
                        name: "FK_ApacAircraftTrack_Position_positionid",
                        column: x => x.positionid,
                        principalTable: "Position",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FiledRouteElement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seqNum = table.Column<int>(type: "int", nullable: false),
                    positionid = table.Column<int>(type: "int", nullable: true),
                    airway = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    airwayType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changeSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changeLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changeOfFlightRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiledRouteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiledRouteElement", x => x.id);
                    table.ForeignKey(
                        name: "FK_FiledRouteElement_FiledRoute_FiledRouteid",
                        column: x => x.FiledRouteid,
                        principalTable: "FiledRoute",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FiledRouteElement_Position_positionid",
                        column: x => x.positionid,
                        principalTable: "Position",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TrajRouteElement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seqNum = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actualTimeOver = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calculatedTimeOver = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estimatedTimeOver = table.Column<DateTime>(type: "datetime2", nullable: false),
                    routePointid = table.Column<int>(type: "int", nullable: true),
                    ApacTrajElementsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrajRouteElement", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrajRouteElement_ApacTrajElements_ApacTrajElementsid",
                        column: x => x.ApacTrajElementsid,
                        principalTable: "ApacTrajElements",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TrajRouteElement_RoutePoint_routePointid",
                        column: x => x.routePointid,
                        principalTable: "RoutePoint",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AlternativeAerodrome",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alternativeAerodrome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrivalid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeAerodrome", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlternativeAerodrome_Arrival_Arrivalid",
                        column: x => x.Arrivalid,
                        principalTable: "Arrival",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EnRoute",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currentModeACode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alternativeEnRouteAerodrome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    boundaryCrossingid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnRoute", x => x.id);
                    table.ForeignKey(
                        name: "FK_EnRoute_BoundaryCrossing_boundaryCrossingid",
                        column: x => x.boundaryCrossingid,
                        principalTable: "BoundaryCrossing",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    standardCapabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aircraftColorAndMarking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    communicationid = table.Column<int>(type: "int", nullable: true),
                    navigationid = table.Column<int>(type: "int", nullable: true),
                    survivalid = table.Column<int>(type: "int", nullable: true),
                    aircraftRegistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aircraftAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberOfAircraft = table.Column<int>(type: "int", nullable: false),
                    aircraftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wakeTurbulence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherSurveillanceCapabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aircraftApproachCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.id);
                    table.ForeignKey(
                        name: "FK_Aircraft_Communication_communicationid",
                        column: x => x.communicationid,
                        principalTable: "Communication",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Aircraft_Navigation_navigationid",
                        column: x => x.navigationid,
                        principalTable: "Navigation",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Aircraft_Survival_survivalid",
                        column: x => x.survivalid,
                        principalTable: "Survival",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FlightPlan",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    messageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aircraftIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flightType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specialHandlingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aircraftOperating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flightPlanOriginator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureid = table.Column<int>(type: "int", nullable: true),
                    arrivalid = table.Column<int>(type: "int", nullable: true),
                    aircraftid = table.Column<int>(type: "int", nullable: true),
                    filedRouteid = table.Column<int>(type: "int", nullable: true),
                    enRouteid = table.Column<int>(type: "int", nullable: true),
                    supplementaryid = table.Column<int>(type: "int", nullable: true),
                    gufi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gufiOriginator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apacAircraftTrackid = table.Column<int>(type: "int", nullable: true),
                    apacTrajElementsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPlan", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightPlan_Aircraft_aircraftid",
                        column: x => x.aircraftid,
                        principalTable: "Aircraft",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_ApacAircraftTrack_apacAircraftTrackid",
                        column: x => x.apacAircraftTrackid,
                        principalTable: "ApacAircraftTrack",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_ApacTrajElements_apacTrajElementsid",
                        column: x => x.apacTrajElementsid,
                        principalTable: "ApacTrajElements",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_Arrival_arrivalid",
                        column: x => x.arrivalid,
                        principalTable: "Arrival",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_Departure_departureid",
                        column: x => x.departureid,
                        principalTable: "Departure",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_EnRoute_enRouteid",
                        column: x => x.enRouteid,
                        principalTable: "EnRoute",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_FiledRoute_filedRouteid",
                        column: x => x.filedRouteid,
                        principalTable: "FiledRoute",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_Supplementary_supplementaryid",
                        column: x => x.supplementaryid,
                        principalTable: "Supplementary",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SurveillanceCapabilitiesCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surveillanceCapabilitiesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aircraftid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveillanceCapabilitiesCode", x => x.id);
                    table.ForeignKey(
                        name: "FK_SurveillanceCapabilitiesCode_Aircraft_Aircraftid",
                        column: x => x.Aircraftid,
                        principalTable: "Aircraft",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_communicationid",
                table: "Aircraft",
                column: "communicationid");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_navigationid",
                table: "Aircraft",
                column: "navigationid");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_survivalid",
                table: "Aircraft",
                column: "survivalid");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeAerodrome_Arrivalid",
                table: "AlternativeAerodrome",
                column: "Arrivalid");

            migrationBuilder.CreateIndex(
                name: "IX_ApacAircraftTrack_positionid",
                table: "ApacAircraftTrack",
                column: "positionid");

            migrationBuilder.CreateIndex(
                name: "IX_Arrival_apacArrivalid",
                table: "Arrival",
                column: "apacArrivalid");

            migrationBuilder.CreateIndex(
                name: "IX_BoundaryCrossing_crossingPointid",
                table: "BoundaryCrossing",
                column: "crossingPointid");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationCapabilityCode_Communicationid",
                table: "CommunicationCapabilityCode",
                column: "Communicationid");

            migrationBuilder.CreateIndex(
                name: "IX_DataLinkCapabilityCode_Communicationid",
                table: "DataLinkCapabilityCode",
                column: "Communicationid");

            migrationBuilder.CreateIndex(
                name: "IX_Departure_apacDepartureid",
                table: "Departure",
                column: "apacDepartureid");

            migrationBuilder.CreateIndex(
                name: "IX_EnRoute_boundaryCrossingid",
                table: "EnRoute",
                column: "boundaryCrossingid");

            migrationBuilder.CreateIndex(
                name: "IX_FiledRouteElement_FiledRouteid",
                table: "FiledRouteElement",
                column: "FiledRouteid");

            migrationBuilder.CreateIndex(
                name: "IX_FiledRouteElement_positionid",
                table: "FiledRouteElement",
                column: "positionid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_aircraftid",
                table: "FlightPlan",
                column: "aircraftid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_apacAircraftTrackid",
                table: "FlightPlan",
                column: "apacAircraftTrackid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_apacTrajElementsid",
                table: "FlightPlan",
                column: "apacTrajElementsid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_arrivalid",
                table: "FlightPlan",
                column: "arrivalid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_departureid",
                table: "FlightPlan",
                column: "departureid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_enRouteid",
                table: "FlightPlan",
                column: "enRouteid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_filedRouteid",
                table: "FlightPlan",
                column: "filedRouteid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_supplementaryid",
                table: "FlightPlan",
                column: "supplementaryid");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationCapabilitiesCode_Navigationid",
                table: "NavigationCapabilitiesCode",
                column: "Navigationid");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceBasedCode_Navigationid",
                table: "PerformanceBasedCode",
                column: "Navigationid");

            migrationBuilder.CreateIndex(
                name: "IX_SurveillanceCapabilitiesCode_Aircraftid",
                table: "SurveillanceCapabilitiesCode",
                column: "Aircraftid");

            migrationBuilder.CreateIndex(
                name: "IX_Survival_dinghiesid",
                table: "Survival",
                column: "dinghiesid");

            migrationBuilder.CreateIndex(
                name: "IX_TrajRouteElement_ApacTrajElementsid",
                table: "TrajRouteElement",
                column: "ApacTrajElementsid");

            migrationBuilder.CreateIndex(
                name: "IX_TrajRouteElement_routePointid",
                table: "TrajRouteElement",
                column: "routePointid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativeAerodrome");

            migrationBuilder.DropTable(
                name: "CommunicationCapabilityCode");

            migrationBuilder.DropTable(
                name: "DataLinkCapabilityCode");

            migrationBuilder.DropTable(
                name: "FiledRouteElement");

            migrationBuilder.DropTable(
                name: "FlightPlan");

            migrationBuilder.DropTable(
                name: "NavigationCapabilitiesCode");

            migrationBuilder.DropTable(
                name: "PerformanceBasedCode");

            migrationBuilder.DropTable(
                name: "SurveillanceCapabilitiesCode");

            migrationBuilder.DropTable(
                name: "TrajRouteElement");

            migrationBuilder.DropTable(
                name: "ApacAircraftTrack");

            migrationBuilder.DropTable(
                name: "Arrival");

            migrationBuilder.DropTable(
                name: "Departure");

            migrationBuilder.DropTable(
                name: "EnRoute");

            migrationBuilder.DropTable(
                name: "FiledRoute");

            migrationBuilder.DropTable(
                name: "Supplementary");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "ApacTrajElements");

            migrationBuilder.DropTable(
                name: "RoutePoint");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "ApacArrival");

            migrationBuilder.DropTable(
                name: "ApacDeparture");

            migrationBuilder.DropTable(
                name: "BoundaryCrossing");

            migrationBuilder.DropTable(
                name: "Communication");

            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropTable(
                name: "Survival");

            migrationBuilder.DropTable(
                name: "CrossingPoint");

            migrationBuilder.DropTable(
                name: "Dinghies");
        }
    }
}
