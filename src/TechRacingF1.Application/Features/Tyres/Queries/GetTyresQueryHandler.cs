using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Tyres.Queries
{
    public class GetTyresQueryHandler(ITyreRepository tyreRepository, IMapper mapper) : IRequestHandler<GetTyresQuery, List<TyreDTO>>
    {

        public async Task<List<TyreDTO>> Handle(GetTyresQuery request, CancellationToken cancellationToken)
        {
            var tyres = await tyreRepository.GetAll();
            return mapper.Map<List<TyreDTO>>(tyres);
        }
    }
}
