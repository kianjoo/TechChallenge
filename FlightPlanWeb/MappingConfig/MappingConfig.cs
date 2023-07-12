using AutoMapper;
using FlightplanWeb.Models;

namespace FlightplanWeb
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

            CreateMap<FlightPlan, FlightPlan>().ReverseMap();
            CreateMap<Departure, Departure>().ReverseMap();
            CreateMap<ApacDeparture, ApacDeparture>().ReverseMap();
            CreateMap<Arrival, Arrival>().ReverseMap();
            CreateMap<ApacArrival, ApacArrival>().ReverseMap();
            CreateMap<Aircraft, Aircraft>().ReverseMap();
            CreateMap<Communication, Communication>().ReverseMap();
            CreateMap<Navigation, Navigation>().ReverseMap();
            CreateMap<Survival, Survival>().ReverseMap();
            CreateMap<Dinghies, Dinghies>().ReverseMap();
            CreateMap<ApacAircraftTrack, ApacAircraftTrack>().ReverseMap();
            CreateMap<FiledRoute, FiledRoute>().ReverseMap();
            CreateMap<FiledRouteElement, FiledRouteElement>();
            CreateMap<Position, Position>().ReverseMap();
            CreateMap<EnRoute, EnRoute>().ReverseMap();
            CreateMap<BoundaryCrossing, BoundaryCrossing>().ReverseMap();
            CreateMap<CrossingPoint, CrossingPoint>().ReverseMap();
            CreateMap<RoutePoint, RoutePoint>().ReverseMap();
            CreateMap<Supplementary, Supplementary>().ReverseMap();
            CreateMap<ApacTrajElements, ApacTrajElements>().ReverseMap();
            CreateMap<TrajRouteElement, TrajRouteElement>().ReverseMap();
        }
    }
}
