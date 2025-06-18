using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Drivers.Queries
{
    public class GetDriversQueryHandler(IDriverRepository driversRepository, IMapper mapper) : IRequestHandler<GetDriversQuery, List<DriverDTO>>
    {

        public async Task<List<DriverDTO>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await driversRepository.GetAll();
            return mapper.Map<List<DriverDTO>>(drivers);

        }
    }
}
