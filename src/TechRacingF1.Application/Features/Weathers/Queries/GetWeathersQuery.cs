using MediatR;

namespace TechRacingF1.Application.Features.Weathers.Queries
{
    public class GetWeathersQuery : IRequest<List<WeatherDTO>>
    {

    }
}
