using AutoMapper;
using TechRacingF1.Application.Features.Drivers.Queries;
using TechRacingF1.Application.Features.Simulations.Queries;
using TechRacingF1.Application.Features.Strategies.Queries;
using TechRacingF1.Application.Features.Tracks.Queries;
using TechRacingF1.Application.Features.Weathers.Queries;
using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Application.Features.Simulations
{
    public class SimulationProfile : Profile
    {
        public SimulationProfile()
        {
            CreateMap<Simulation, SimulationDTO>()
                .ForMember(dest => dest.Strategy, opt => opt.MapFrom(src => src.Strategy))
                .ForMember(dest => dest.Weather, opt => opt.MapFrom(src => src.Weather))
                .ForMember(dest => dest.Track, opt => opt.MapFrom(src => src.Track))
                .ReverseMap();

            CreateMap<Strategy, StrategyDTO>()
                .ForMember(dest => dest.StrategyId, opt => opt.MapFrom(src => src.StrategyId))
                .ForMember(dest => dest.StrategyName, opt => opt.MapFrom(src => src.StrategyName))
                .ForMember(dest => dest.TotalLaps, opt => opt.MapFrom(src => src.TotalLaps))
                .ForMember(dest => dest.PlannedStops, opt => opt.MapFrom(src => src.PlannedStops))
                .ForMember(dest => dest.EstimatedTime, opt => opt.MapFrom(src => src.EstimatedTime))
                .ForMember(dest => dest.Risk, opt => opt.MapFrom(src => src.Risk))
                .ForMember(dest => dest.WeatherId, opt => opt.MapFrom(src => src.WeatherId))
                .ForMember(dest => dest.TrackId, opt => opt.MapFrom(src => src.TrackId))
                .ReverseMap();

            CreateMap<Weather, WeatherDTO>()
                .ForMember(dest => dest.WeatherId, opt => opt.MapFrom(src => src.WeatherId))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Humidity))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
                .ForMember(dest => dest.RiskFactor, opt => opt.MapFrom(src => src.RiskFactor))
                .ReverseMap();

            CreateMap<Track, TrackDTO>()
                .ForMember(dest => dest.TrackId, opt => opt.MapFrom(src => src.TrackId))
                .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.TrackName))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.TrackLength, opt => opt.MapFrom(src => src.TrackLength))
                .ForMember(dest => dest.Curves, opt => opt.MapFrom(src => src.Curves))
                .ForMember(dest => dest.AsphaltType, opt => opt.MapFrom(src => src.AsphaltType))
                .ForMember(dest => dest.TyreWear, opt => opt.MapFrom(src => src.TyreWear))
                .ReverseMap();

            CreateMap<Driver, DriverDTO>()
            .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.DriverId))
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.Fullname))
            .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team))
            .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
            .ForMember(dest => dest.DriverLevel, opt => opt.MapFrom(src => src.DriverLevel))
            .ForMember(dest => dest.Truculence, opt => opt.MapFrom(src => src.Truculence))
            .ForMember(dest => dest.Experience, opt => opt.MapFrom(src => src.Experience))
            .ReverseMap();
        }
    }
}