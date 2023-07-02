using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightPlanWeb.Models
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
        public DateTime lastUpdatedTimeStamp { get; set; }
        public string? src { get; set; }
        public ApacAircraftTrack? apacAircraftTrack { get; set; }
        public ApacTrajElements? apacTrajElements { get; set; }
    }

    public class Departure
    {
        [JsonIgnore]
        public int id { get; set; }
        public ApacDeparture? apacDeparture { get; set; }
        public string? departureAerodrome { get; set; }
        public string? dateOfFlight { get; set; }
        public string? estimatedOffBLockTime { get; set; }
        public DateTime actualTimeOfDeparture { get; set; }
        public string? runwayDirection { get; set; }
        public string? airportSlotIdentification { get; set; }
        public string? departureAlternativeAerodrome { get; set; }
    }

    public class ApacDeparture
    {
        [JsonIgnore]
        public int id { get; set; }
        public DateTime actualOffBlockTime { get; set; }
        public DateTime calculatedTakeOffTime { get; set; }
        public DateTime targetOffBlockTime { get; set; }
        public DateTime targetStartupApprovalTime { get; set; }
        public DateTime targetedTakeOffTime { get; set; }
    }


    public class Arrival
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? destinationAerodrome { get; set; }
        [JsonProperty("alternativeAerodrome")]
        public List<AlternativeAerodrome>? alternativeAerodromeList { get; set; }
        public string? airportSlotIdentification { get; set; }
        public string? arrivalRunwayDirection { get; set; }
        public string? arrivalAerodrome { get; set; }
        public DateTime? actualTimeOfArrival { get; set; }
        public ApacArrival? apacArrival { get; set; }
    }

    public class AlternativeAerodrome
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? alternativeAerodrome { get; set; }
    }

    public class ApacArrival
    {
        [JsonIgnore]
        public int id { get; set; }
        public DateTime calculatedLandingTime { get; set; }
        public DateTime estimatedLandingTime { get; set; }
    }

    public class Aircraft
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? standardCapabilities { get; set; }
        public string? aircraftColorAndMarking { get; set; }
        public Communication? communication { get; set; }
        public Navigation? navigation { get; set; }
        public Survival? survival { get; set; }
        [JsonProperty("surveillanceCapabilitiesCodes")]
        public List<SurveillanceCapabilitiesCode>? surveillanceCapabilitiesCodeList { get; set; }
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
        [JsonIgnore]
        public int id { get; set; }
        public string? surveillanceCapabilitiesCode { get; set; }
    }

    public class Communication
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonProperty("communicationCapabilityCode")]
        public List<CommunicationCapabilityCode>? communicationCapabilityCodeList { get; set; }
        [JsonProperty("dataLinkCapabilityCode")]
        public List<DataLinkCapabilityCode>? dataLinkCapabilityCodeList { get; set; }
        public string? selectiveCallingCode { get; set; }
        public string? otherCommunicationCapabilities { get; set; }
        public string? otherDataLinkCapabilities { get; set; }
    }

    public class CommunicationCapabilityCode
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? communicationCapabilityCode { get; set; }
    }

    public class DataLinkCapabilityCode
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? dataLinkCapabilityCode { get; set; }
    }

    public class Navigation
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonProperty("navigationCapabilitiesCode")]
        public List<NavigationCapabilitiesCode>? navigationCapabilitiesCodeList { get; set; }
        [JsonProperty("performanceBasedCode")]
        public List<PerformanceBasedCode>? performanceBasedCodeList { get; set; }
        public string? otherNavigationCapabilities { get; set; }
    }

    public class NavigationCapabilitiesCode
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? navigationCapabilitiesCode { get; set; }
    }

    public class PerformanceBasedCode
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? performanceBasedCode { get; set; }
    }

    public class Survival
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? survivalEquipment { get; set; }
        public string? otherSurvivalEquipment { get; set; }
        public string? emergencyRadioCapability { get; set; }
        public string? lifeJacket { get; set; }
        public Dinghies? dinghies { get; set; }
    }

    public class Dinghies
    {
        [JsonIgnore]
        public int id { get; set; }
        public int carried { get; set; }
        public int totalCapacity { get; set; }
        public bool covered { get; set; }
        public string? color { get; set; }
    }

    public class ApacAircraftTrack
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? actualSpeed { get; set; }
        public string? flightLevel { get; set; }
        public string? heading { get; set; }
        public DateTime positionTime { get; set; }
        public Position? position { get; set; }
    }

    public class FiledRoute
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonProperty("RouteElement")]
        public List<FiledRouteElement>? routeElement { get; set; }
    }

    public class FiledRouteElement
    {
        [JsonIgnore]
        public int id { get; set; }
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
        [JsonIgnore]
        public int id { get; set; }
        public int lat { get; set; }
        public int lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class EnRoute
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? currentModeACode { get; set; }
        public string? alternativeEnRouteAerodrome { get; set; }
        public BoundaryCrossing? boundaryCrossing { get; set; }
    }

    public class BoundaryCrossing
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? crossingTime { get; set; }
        public string? clearLevel { get; set; }
        public string? condition { get; set; }
        public string? supplementaryCrossingLevel { get; set; }
        public CrossingPoint? crossingPoint { get; set; }
    }

    public class CrossingPoint
    {
        [JsonIgnore]
        public int id { get; set; }
        public int lat { get; set; }
        public int lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class RoutePoint
    {
        [JsonIgnore]
        public int id { get; set; }
        public int lat { get; set; }
        public int lon { get; set; }
        public string? designatedPoint { get; set; }
        public string? bearing { get; set; }
        public string? distance { get; set; }
    }

    public class Supplementary
    {
        [JsonIgnore]
        public int id { get; set; }
        public string? fuelEnduranceTime { get; set; }
        public string? totalNumberOfPeople { get; set; }
        public string? nameOfPilot { get; set; }
    }

    public class ApacTrajElements
    {
        [JsonIgnore]
        public int id { get; set; }
        [JsonProperty("RouteElement")]
        public List<TrajRouteElement>? routeElement { get; set; }
    }

    public class TrajRouteElement
    {
        [JsonIgnore]
        public int id { get; set; }
        public int seqNum { get; set; }
        public string? level { get; set; }
        public DateTime actualTimeOver { get; set; }
        public DateTime calculatedTimeOver { get; set; }
        public DateTime estimatedTimeOver { get; set; }
        public RoutePoint? routePoint { get; set; }
    }
}