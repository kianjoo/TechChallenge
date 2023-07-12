
using FlightPlanAPI.IRepository;
using FlightPlanAPI.Models;
using FlightPlanAPI.Data;
using Azure;
using Newtonsoft.Json;

namespace FlightPlanAPI.Repository
{
    public class FlightPlanRepository: IFlightPlanRepository
    {
        private readonly AppDbContext _db;
        private readonly ILogger<FlightPlanRepository> _logger;
        static int runningId = 0;
        private Random _rnd = new Random();
		List<string> _location = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
		List<int> _travelTime = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
		
        static List<FlightPlan> _flightPlanList = new List<FlightPlan>();

		public FlightPlanRepository(AppDbContext db, ILogger<FlightPlanRepository> logger)
        {
            _logger = logger;
            _db = db;
		}

		public FlightPlan GetRandomFlightPlan()
        {
            int idx = _rnd.Next(_location.Count);

			string departureAerodrome = _location[idx];
			DateTime departureTime = DateTime.Now.AddHours(_rnd.Next(1, 48));

            int nextIdx = 0;

            while ((nextIdx = _rnd.Next(_location.Count)) == idx) ;

            int travelTime = Math.Abs(_travelTime[nextIdx] - _travelTime[idx]);
            string arrivalAerodrome = _location[nextIdx];
			DateTime arrivalTime = departureTime.AddMinutes(_rnd.Next(1, 60)).AddHours(+travelTime);

			FlightPlan flightPlan = new FlightPlan
            {
                id = (++runningId).ToString(),
                messageType = "FPL",
                aircraftIdentification = "SIA2"+ runningId.ToString("###"),
                flightType = "M",
                specialHandlingReason = "FFR",
                aircraftOperating = "SIA",
                flightPlanOriginator = "SIA",
                remark = "ACASII EQUIPPED TCAS",
                departure = new Departure
                {
                    apacDeparture = new ApacDeparture
                    {
                        actualOffBlockTime = DateTime.Now,
                        calculatedTakeOffTime = DateTime.Now,
                        targetOffBlockTime = DateTime.Now,
                        targetStartupApprovalTime = DateTime.Now,
                        targetedTakeOffTime = DateTime.Now
                    },
                    departureAerodrome = departureAerodrome,
                    dateOfFlight = "WSSS",
                    estimatedOffBLockTime = DateTime.Now.ToString("HH:mm:ss"),
                    actualTimeOfDeparture = departureTime,
                    runwayDirection = "O1L",
                    airportSlotIdentification = "O1L",
                    departureAlternativeAerodrome = "WSSS",
                },
                arrival = new Arrival
                {
                    destinationAerodrome = "WSSS",
                    alternativeAerodrome = new List<string>
                        {
                               "string"
                        },
                    airportSlotIdentification = "01L",
                    arrivalRunwayDirection = "01L",
                    arrivalAerodrome = arrivalAerodrome,
                    actualTimeOfArrival = arrivalTime,
                    apacArrival = new ApacArrival
                    {
                        calculatedLandingTime = DateTime.Now,
                        estimatedLandingTime = DateTime.Now
                    }
                },
                aircraft = new Aircraft
                {
                    standardCapabilities = "S",
                    aircraftColorAndMarking = "string",
                    communication = new Communication
                    {
                        communicationCapabilityCode = new List<string>
                            {
                                    "string 1","string 2"
                            },
                        dataLinkCapabilityCode = new List<string>
                            {
                                    "string 3","string 4"
                            },
                        selectiveCallingCode = "string",
                        otherCommunicationCapabilities = "string",
                        otherDataLinkCapabilities = "string",
                    },
                    navigation = new Navigation
                    {
                        navigationCapabilitiesCode = new List<string>
                            {
                                    "string"
                            },
                        performanceBasedCode = new List<string>
                            {
                                    "string"
                            },
                        otherNavigationCapabilities = "string"
                    },
                    survival = new Survival
                    {
                        survivalEquipment = "string",
                        otherSurvivalEquipment = "string",
                        emergencyRadioCapability = "string",
                        lifeJacket = "string",
                        dinghies = new Dinghies
                        {
                            carried = 0,
                            totalCapacity = 0,
                            covered = true,
                            color = "string"
                        }
                    },
                    surveillanceCapabilitiesCodes = new List<string>
                    {
                            "string"
                    },
                    aircraftRegistration = "9VSHN",
                    aircraftAddress = "76CD0E",
                    numberOfAircraft = 0,
                    aircraftType = "A359",
                    wakeTurbulence = "H",
                    otherSurveillanceCapabilities = "string",
                    aircraftApproachCategory = "C",
                },
                filedRoute = new FiledRoute
                {
                    routeElement = new List<FiledRouteElement>
                        {
                            new FiledRouteElement
                            {
                                seqNum = 0,
                                position= new Position
                                {
                                    lat=0,
                                    lon=0,
                                    designatedPoint="KAT",
                                    bearing="string",
                                    distance="string"
                                },
                                airway="string",
                                airwayType="NAMED",
                                changeSpeed="486.0 N",
                                changeLevel="410.0 F",
                                changeOfFlightRule="410.0 F",
                            }
                        },
                },
                enRoute = new EnRoute
                {
                    currentModeACode = "string",
                    alternativeEnRouteAerodrome = "WILL YPPH",
                    boundaryCrossing = new BoundaryCrossing
                    {
                        crossingTime = "string",
                        clearLevel = "string",
                        condition = "string",
                        supplementaryCrossingLevel = "string",
                        crossingPoint = new CrossingPoint
                        {
                            lat = 0,
                            lon = 0,
                            designatedPoint = "KAT",
                            bearing = "string",
                            distance = "string"
                        }
                    }
                },
                supplementary = new Supplementary
                {
                    fuelEnduranceTime = "string",
                    totalNumberOfPeople = "string",
                    nameOfPilot = "string"
                },
                gufi = "01bdb5c8-7351-4d25-9032-815f88398958",
                gufiOriginator = "SIA",
                lastUpdatedTimeStamp = DateTime.Now,
                src = "AFTN",
                apacAircraftTrack = new ApacAircraftTrack
                {
                    actualSpeed = "string",
                    flightLevel = "string",
                    heading = "string",
                    positionTime = DateTime.Now,
                    position = new Position
                    {
                        lat = 0,
                        lon = 0,
                        designatedPoint = "KAT",
                        bearing = "string",
                        distance = "string"
                    }
                },
                apacTrajElements = new ApacTrajElements
                {
                    routeElement = new List<TrajRouteElement>
                        {
                            new TrajRouteElement
                            {
                                seqNum  =0,
                                level="string",
                                actualTimeOver=DateTime.Now,
                                calculatedTimeOver=DateTime.Now,
                                estimatedTimeOver=DateTime.Now,
                                routePoint=new RoutePoint
                                {
                                    lat= 0,
                                    lon=0,
                                    designatedPoint="KAT",
                                    bearing="string",
                                    distance="string",
                                }
                            }
                        }
                }
            };


            return flightPlan;
        }

        public string GetMockData(string filename)
        {
            string mockData = String.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
					mockData = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return mockData;
        }

		public List<FlightPlan> GenerateFlightPlan()
		{
			_flightPlanList.Clear();
			for (int i = 0; i < 2000; ++i)
			{
				_flightPlanList.Add(GetRandomFlightPlan());
			};

            return _flightPlanList;
		}
		
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

		public List<FlightPlan> GetFlightPlanList()
		{
            return _flightPlanList;
		}
	}
}
