using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Tracks.Queries
{
    public class GetTracksQueryHandler(ITrackRepository tracksRepository, IMapper mapper) : IRequestHandler<GetTracksQuery, List<TrackDTO>>
    {

        public async Task<List<TrackDTO>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            var strategies = await tracksRepository.GetAll();
            return mapper.Map<List<TrackDTO>>(strategies);
        }
    }
}
