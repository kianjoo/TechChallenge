using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightPlanWeb.Models.DTO
{
    public class FlightPlanDTO
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
        public DepartureDTO? departure { get; set; }
        public ArrivalDTO? arrival { get; set; }
        public AircraftDTO? aircraft { get; set; }
        public FiledRouteDTO? filedRoute { get; set; }
        public EnRouteDTO? enRoute { get; set; }
        public SupplementaryDTO? supplementary { get; set; }
        public string? gufi { get; set; }
        public string? gufiOriginator { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime lastUpdatedTimeStamp { get; set; }
        public string? src { get; set; }
        public ApacAircraftTrackDTO? apacAircraftTrack { get; set; }
        public ApacTrajElementsDTO? apacTrajElements { get; set; }
    }

    public class DepartureDTO
    {
        public ApacDepartureDTO? apacDeparture { get; set; }
        public string? departureAerodrome { get; set; }
        public string? dateOfFlight { get; set; }
        public string? estimatedOffBLockTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualTimeOfDeparture { get; set; }
        public string? runwayDirection { get; set; }
        public string? airportSlotIdentification { get; set; }
        public string? departureAlternativeAerodrome { get; set; }
    }

    public class ApacDepartureDTO
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


    public class ArrivalDTO
    {
        public string? destinationAerodrome { get; set; }
        public List<string>? alternativeAerodrome { get; set; }
        public string? airportSlotIdentification { get; set; }
        public string? arrivalRunwayDirection { get; set; }
        public string? arrivalAerodrome { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualTimeOfArrival { get; set; }
        public ApacArrivalDTO? apacArrival { get; set; }
    }

    public class AlternativeAerodromeDTO
    {
        public string? alternativeAerodrome { get; set; }
    }

    public class ApacArrivalDTO
    {
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime calculatedLandingTime { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime estimatedLandingTime { get; set; }
    }

    public class AircraftDTO
    {
        public string? standardCapabilities { get; set; }
        public string? aircraftColorAndMarking { get; set; }
        public CommunicationDTO? communication { get; set; }
        public NavigationDTO? navigation { get; set; }
        public SurvivalDTO? survival { get; set; }
        public List<string>? surveillanceCapabilitiesCodes { get; set; }
        public string? aircraftRegistration { get; set; }
        public string? aircraftAddress { get; set; }
        public int numberOfAircraft { get; set; }
        public string? aircraftType { get; set; }
        public string? wakeTurbulence { get; set; }
        public string? otherSurveillanceCapabilities { get; set; }
        public string? aircraftApproachCategory { get; set; }
    }

    public class SurveillanceCapabilitiesCodeDTO
    {
        public string? surveillanceCapabilitiesCode { get; set; }
    }

    public class CommunicationDTO
    {
        public List<string>? communicationCapabilityCode { get; set; }
        public List<string>? dataLinkCapabilityCode { get; set; }
        public string? selectiveCallingCode { get; set; }
        public string? otherCommunicationCapabilities { get; set; }
        public string? otherDataLinkCapabilities { get; set; }
    }


    public class NavigationDTO
    {
        public List<string>? navigationCapabilitiesCode { get; set; }
        public List<string>? performanceBasedCode { get; set; }
        public string? otherNavigationCapabilities { get; set; }
    }


    public class SurvivalDTO
    {
        public string? survivalEquipment { get; set; }
        public string? otherSurvivalEquipment { get; set; }
        public string? emergencyRadioCapability { get; set; }
        public string? lifeJacket { get; set; }
        public DinghiesDTO? dinghies { get; set; }
    }

    public class DinghiesDTO
    {
        public int carried { get; set; }
        public int totalCapacity { get; set; }
        public bool covered { get; set; }
        public string? color { get; set; }
    }

    public class ApacAircraftTrackDTO
    {
        public string? actualSpeed { get; set; }
        public string? flightLevel { get; set; }
        public string? heading { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime positionTime { get; set; }
        public Position? position { get; set; }
    }

    public class FiledRouteDTO
    {
        [JsonProperty("RouteElement")]
        public List<FiledRouteElementDTO>? routeElement { get; set; }
    }

    public class FiledRouteElementDTO
    {
        public int seqNum { get; set; }
        public PositionDTO? position { get; set; }
        public string? airway { get; set; }
        public string? airwayType { get; set; }
        public string? changeSpeed { get; set; }
        public string? changeLevel { get; set; }
        public string? changeOfFlightRule { get; set; }
    }

    public class PositionDTO
    {
        public int lat { get; set; }
        public int lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class EnRouteDTO
    {
        public string? currentModeACode { get; set; }
        public string? alternativeEnRouteAerodrome { get; set; }
        public BoundaryCrossingDTO? boundaryCrossing { get; set; }
    }

    public class BoundaryCrossingDTO
    {
        public string? crossingTime { get; set; }
        public string? clearLevel { get; set; }
        public string? condition { get; set; }
        public string? supplementaryCrossingLevel { get; set; }
        public CrossingPoint? crossingPoint { get; set; }
    }

    public class CrossingPointDTO
    {
        public int lat { get; set; }
        public int lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class RoutePointDTO
    {
        public int lat { get; set; }
        public int lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class SupplementaryDTO
    {
        public string? fuelEnduranceTime { get; set; }
        public string? totalNumberOfPeople { get; set; }
        public string? nameOfPilot { get; set; }
    }

    public class ApacTrajElementsDTO
    {
        [JsonProperty("RouteElement")]
        public List<TrajRouteElementDTO>? routeElement { get; set; }
    }

    public class TrajRouteElementDTO
    {
        public int seqNum { get; set; }
        public string? level { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime actualTimeOver { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy HH:mm:ss.fffZ")]
		public DateTime calculatedTimeOver { get; set; }
        public DateTime estimatedTimeOver { get; set; }
        public RoutePointDTO? routePoint { get; set; }
    }
}