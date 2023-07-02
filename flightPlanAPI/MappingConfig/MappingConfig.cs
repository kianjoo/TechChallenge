using AutoMapper;
using FlightPlanAPI.Models;
using FlightPlanAPI.Models.DTO;

namespace FlightPlanAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<FlightPlan, FlightPlanDTO>().ReverseMap();
            CreateMap<Departure, DepartureDTO>().ReverseMap();
            CreateMap<ApacDeparture, ApacDepartureDTO>().ReverseMap();
            CreateMap<Arrival, ArrivalDTO>().ReverseMap();
            CreateMap<ApacArrival, ApacArrivalDTO>().ReverseMap();
            CreateMap<Aircraft, AircraftDTO>().ReverseMap();
            CreateMap<Communication, CommunicationDTO>().ReverseMap();
            CreateMap<Navigation, NavigationDTO>().ReverseMap();
            CreateMap<Survival, SurvivalDTO>().ReverseMap();
            CreateMap<Dinghies, DinghiesDTO>().ReverseMap();
            CreateMap<ApacAircraftTrack, ApacAircraftTrackDTO>().ReverseMap();
            CreateMap<FiledRoute, FiledRouteDTO>().ReverseMap();
            CreateMap<FiledRouteElement, FiledRouteElementDTO>();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<EnRoute, EnRouteDTO>().ReverseMap();
            CreateMap<BoundaryCrossing, BoundaryCrossingDTO>().ReverseMap();
            CreateMap<CrossingPoint, CrossingPointDTO>().ReverseMap();
            CreateMap<RoutePoint, RoutePointDTO>().ReverseMap();
            CreateMap<Supplementary, SupplementaryDTO>().ReverseMap();
            CreateMap<ApacTrajElements, ApacTrajElementsDTO>().ReverseMap();
            CreateMap<TrajRouteElement, TrajRouteElementDTO>().ReverseMap();

            //CreateMap<FlightPlanDTO, FlightPlan>().ReverseMap();
            //CreateMap<DepartureDTO, Departure>().ReverseMap();
            //CreateMap<ApacDepartureDTO, ApacDeparture>().ReverseMap();
            //CreateMap<ArrivalDTO, Arrival>().ReverseMap();
            //CreateMap<AlternativeAerodromeDTO, AlternativeAerodrome>().ReverseMap();
            //CreateMap<ApacArrivalDTO, ApacArrival>().ReverseMap();
            //CreateMap<AircraftDTO, Aircraft>().ReverseMap();
            //CreateMap<SurveillanceCapabilitiesCodeDTO, SurveillanceCapabilitiesCode>().ReverseMap();
            //CreateMap<CommunicationDTO, Communication>().ReverseMap();
            //CreateMap<CommunicationCapabilityCodeDTO, CommunicationCapabilityCode>().ReverseMap();
            //CreateMap<DataLinkCapabilityCodeDTO, DataLinkCapabilityCode>().ReverseMap();
            //CreateMap<NavigationDTO, Navigation>().ReverseMap();
            //CreateMap<NavigationCapabilitiesCodeDTO, NavigationCapabilitiesCode>().ReverseMap();
            //CreateMap<PerformanceBasedCodeDTO, PerformanceBasedCode>().ReverseMap();
            //CreateMap<SurvivalDTO, Survival>().ReverseMap();
            //CreateMap<DinghiesDTO, Dinghies>().ReverseMap();
            //CreateMap<ApacAircraftTrackDTO, ApacAircraftTrack>().ReverseMap();
            //CreateMap<FiledRouteDTO, FiledRoute>().ReverseMap();
            //CreateMap<FiledRouteElementDTO, FiledRouteElement>();
            //CreateMap<PositionDTO, Position>().ReverseMap();
            //CreateMap<EnRouteDTO, EnRoute>().ReverseMap();
            //CreateMap<BoundaryCrossingDTO, BoundaryCrossing>().ReverseMap();
            //CreateMap<CrossingPointDTO, CrossingPoint>().ReverseMap();
            //CreateMap<RoutePointDTO, RoutePoint>().ReverseMap();
            //CreateMap<SupplementaryDTO, Supplementary>().ReverseMap();
            //CreateMap<ApacTrajElementsDTO, ApacTrajElements>().ReverseMap();
            //CreateMap<TrajRouteElementDTO, TrajRouteElement>().ReverseMap();
        }
    }
}
