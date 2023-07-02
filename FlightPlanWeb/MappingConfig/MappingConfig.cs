using AutoMapper;
using FlightPlanWeb.Models;
using FlightPlanWeb.Models.DTO;

namespace FlightPlanWeb
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            //CreateMap<FlightPlan, FlightPlanDTO>().ReverseMap();
            //CreateMap<Departure, DepartureDTO>().ReverseMap();
            //CreateMap<ApacDeparture, ApacDepartureDTO>().ReverseMap();
            //CreateMap<Arrival, ArrivalDTO>().ReverseMap();
            //CreateMap<ApacArrival, ApacArrivalDTO>().ReverseMap();
            //CreateMap<Aircraft, AircraftDTO>().ReverseMap();
            //CreateMap<Communication, CommunicationDTO>().ReverseMap();
            //CreateMap<Navigation, NavigationDTO>().ReverseMap();
            //CreateMap<Survival, SurvivalDTO>().ReverseMap();
            //CreateMap<Dinghies, DinghiesDTO>().ReverseMap();
            //CreateMap<ApacAircraftTrack, ApacAircraftTrackDTO>().ReverseMap();
            //CreateMap<FiledRoute, FiledRouteDTO>().ReverseMap();
            //CreateMap<FiledRouteElement, FiledRouteElementDTO>();
            //CreateMap<Position, PositionDTO>().ReverseMap();
            //CreateMap<EnRoute, EnRouteDTO>().ReverseMap();
            //CreateMap<BoundaryCrossing, BoundaryCrossingDTO>().ReverseMap();
            //CreateMap<CrossingPoint, CrossingPointDTO>().ReverseMap();
            //CreateMap<RoutePoint, RoutePointDTO>().ReverseMap();
            //CreateMap<Supplementary, SupplementaryDTO>().ReverseMap();
            //CreateMap<ApacTrajElements, ApacTrajElementsDTO>().ReverseMap();
            //CreateMap<TrajRouteElement, TrajRouteElementDTO>().ReverseMap();

            CreateMap<FlightPlanDTO, FlightPlan>().ReverseMap();
            CreateMap<DepartureDTO, Departure>().ReverseMap();
            CreateMap<ApacDepartureDTO, ApacDeparture>().ReverseMap();
            CreateMap<ArrivalDTO, Arrival>().ReverseMap();
            CreateMap<ApacArrivalDTO, ApacArrival>().ReverseMap();
            CreateMap<AircraftDTO, Aircraft>().ReverseMap();
            CreateMap<CommunicationDTO, Communication>().ReverseMap();
            CreateMap<NavigationDTO, Navigation>().ReverseMap();
            CreateMap<SurvivalDTO, Survival>().ReverseMap();
            CreateMap<DinghiesDTO, Dinghies>().ReverseMap();
            CreateMap<ApacAircraftTrackDTO, ApacAircraftTrack>().ReverseMap();
            CreateMap<FiledRouteDTO, FiledRoute>().ReverseMap();
            CreateMap<FiledRouteElementDTO, FiledRouteElement>();
            CreateMap<PositionDTO, Position>().ReverseMap();
            CreateMap<EnRouteDTO, EnRoute>().ReverseMap();
            CreateMap<BoundaryCrossingDTO, BoundaryCrossing>().ReverseMap();
            CreateMap<CrossingPointDTO, CrossingPoint>().ReverseMap();
            CreateMap<RoutePointDTO, RoutePoint>().ReverseMap();
            CreateMap<SupplementaryDTO, Supplementary>().ReverseMap();
            CreateMap<ApacTrajElementsDTO, ApacTrajElements>().ReverseMap();
            CreateMap<TrajRouteElementDTO, TrajRouteElement>().ReverseMap();
        }
    }
}
