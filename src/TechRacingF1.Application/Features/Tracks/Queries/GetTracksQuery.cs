using MediatR;

namespace TechRacingF1.Application.Features.Tracks.Queries
{
    public class GetTracksQuery : IRequest<List<TrackDTO>>
    {

    }
}
