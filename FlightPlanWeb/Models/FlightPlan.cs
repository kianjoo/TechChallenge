using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightplanWeb.Models
{
    public class FlightPlan
    {
        [JsonProperty("_id")]
        [Key]
        public string? id { get; set; }
        public string? messageType { get; set; }
        public string? aircraftIdentification { get; set; }
        public string? flightType { get; set; }
        public string? specialHandlingReason { get; set; }
        public string? aircraftOperating { get; set; }
        public string? flightPlanOriginator { get; set; }
        public string? remark { get; set; }
        public Departure? departure { get; set; }
        public Arrival? arrival { get; set; }
        public Aircraft? aircraft { get; set; }
        public FiledRoute? filedRoute { get; set; }
        public EnRoute? enRoute { get; set; }
        public Supplementary? supplementary { get; set; }
        public string? gufi { get; set; }
        public string? gufiOriginator { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime lastUpdatedTimeStamp { get; set; }
        public string? src { get; set; }
        public ApacAircraftTrack? apacAircraftTrack { get; set; }
        public ApacTrajElements? apacTrajElements { get; set; }
    }

    public class Departure
    {
        public ApacDeparture? apacDeparture { get; set; }
        public string? departureAerodrome { get; set; }
        public string? dateOfFlight { get; set; }
        public string? estimatedOffBLockTime { get; set; }
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? timeOfFlight { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualTimeOfDeparture { get; set; }
        public string? runwayDirection { get; set; }
        public string? airportSlotIdentification { get; set; }
        public string? departureAlternativeAerodrome { get; set; }
    }

	public class ApacDeparture
    {
        [JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualOffBlockTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime calculatedTakeOffTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime targetOffBlockTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime targetStartupApprovalTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime targetedTakeOffTime { get; set; }
    }


    public class Arrival
    {
        public string? destinationAerodrome { get; set; }
        public List<string>? alternativeAerodrome { get; set; }
        public string? airportSlotIdentification { get; set; }
        public string? arrivalRunwayDirection { get; set; }
        public string? arrivalAerodrome { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? timeOfArrival { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualTimeOfArrival { get; set; }
        public ApacArrival? apacArrival { get; set; }
    }

    public class AlternativeAerodromeDTO
    {
        public string? alternativeAerodrome { get; set; }
    }

    public class ApacArrival
    {
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime calculatedLandingTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime estimatedLandingTime { get; set; }
    }

    public class Aircraft
    {
        public string? standardCapabilities { get; set; }
        public string? aircraftColorAndMarking { get; set; }
        public Communication? communication { get; set; }
        public Navigation? navigation { get; set; }
        public Survival? survival { get; set; }
        public List<string>? surveillanceCapabilitiesCodes { get; set; }
        public string? aircraftRegistration { get; set; }
        public string? aircraftAddress { get; set; }
        public int numberOfAircraft { get; set; }
        public string? aircraftType { get; set; }
        public string? wakeTurbulence { get; set; }
        public string? otherSurveillanceCapabilities { get; set; }
        public string? aircraftApproachCategory { get; set; }
    }

    public class SurveillanceCapabilitiesCode
    {
        public string? surveillanceCapabilitiesCode { get; set; }
    }

    public class Communication
    {
        public List<string>? communicationCapabilityCode { get; set; }
        public List<string>? dataLinkCapabilityCode { get; set; }
        public string? selectiveCallingCode { get; set; }
        public string? otherCommunicationCapabilities { get; set; }
        public string? otherDataLinkCapabilities { get; set; }
    }


    public class Navigation
    {
        public List<string>? navigationCapabilitiesCode { get; set; }
        public List<string>? performanceBasedCode { get; set; }
        public string? otherNavigationCapabilities { get; set; }
    }


    public class Survival
    {
        public string? survivalEquipment { get; set; }
        public string? otherSurvivalEquipment { get; set; }
        public string? emergencyRadioCapability { get; set; }
        public string? lifeJacket { get; set; }
        public Dinghies? dinghies { get; set; }
    }

    public class Dinghies
    {
        public int carried { get; set; }
        public int totalCapacity { get; set; }
        public bool covered { get; set; }
        public string? color { get; set; }
    }

    public class ApacAircraftTrack
    {
        public string? actualSpeed { get; set; }
        public string? flightLevel { get; set; }
        public string? heading { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime positionTime { get; set; }
        public Position? position { get; set; }
    }

    public class FiledRoute
	{
		public string? flightRuleCategory { get; set; }
		public string? cruisingSpeed { get; set; }
		public string? cruisingLevel { get; set; }
        public string? routeText { get; set; } = string.Empty;
		[JsonProperty("RouteElement")]
        public List<FiledRouteElement>? routeElement { get; set; }
    }

    public class FiledRouteElement
    {
        public int seqNum { get; set; }
        public Position? position { get; set; }
        public string? airway { get; set; }
        public string? airwayType { get; set; }
        public string? changeSpeed { get; set; }
        public string? changeLevel { get; set; }
        public string? changeOfFlightRule { get; set; }
    }

    public class Position
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class EnRoute
    {
        public string? currentModeACode { get; set; }
        public string? alternativeEnRouteAerodrome { get; set; }
        public BoundaryCrossing? boundaryCrossing { get; set; }
    }

    public class BoundaryCrossing
    {
        public string? crossingTime { get; set; }
        public string? clearLevel { get; set; }
        public string? condition { get; set; }
        public string? supplementaryCrossingLevel { get; set; }
        public CrossingPoint? crossingPoint { get; set; }
    }

    public class CrossingPoint
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class RoutePoint
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class Supplementary
    {
        public string? fuelEnduranceTime { get; set; }
        public string? totalNumberOfPeople { get; set; }
        public string? nameOfPilot { get; set; }
    }

    public class ApacTrajElements
    {
        [JsonProperty("RouteElement")]
        public List<TrajRouteElement>? routeElement { get; set; }
    }

    public class TrajRouteElement
    {
        public int seqNum { get; set; }
        public string? level { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualTimeOver { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime calculatedTimeOver { get; set; }
        public DateTime estimatedTimeOver { get; set; }
        public RoutePoint? routePoint { get; set; }
    }
}