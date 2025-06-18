using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Weathers.Queries
{
    public class GetWeathersQueryHandler(IWeatherRepository tracksRepository, IMapper mapper) : IRequestHandler<GetWeathersQuery, List<WeatherDTO>>
    {

        public async Task<List<WeatherDTO>> Handle(GetWeathersQuery request, CancellationToken cancellationToken)
        {
            var strategies = await tracksRepository.GetAll();
            return mapper.Map<List<WeatherDTO>>(strategies);
        }
    }
}
