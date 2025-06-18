using MediatR;

namespace TechRacingF1.Application.Features.Drivers.Queries
{
    public class GetDriversQuery : IRequest<List<DriverDTO>>
    {

    }
}
