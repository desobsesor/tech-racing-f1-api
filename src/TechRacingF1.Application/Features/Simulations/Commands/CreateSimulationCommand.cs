using MediatR;
using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Application.Features.Simulations.Commands
{
    public class CreateSimulationCommand(Simulation simulation) : IRequest<int>
    {
        public int SimulationId { get; set; } = simulation.SimulationId;
        public int StrategyId { get; set; } = simulation.StrategyId;
        public DateTime ExecutionDate { get; set; } = simulation.ExecutionDate;
        public int WeatherId { get; set; } = simulation.WeatherId;
        public int TrackId { get; set; } = simulation.TrackId;
        public decimal TotalTime { get; set; } = simulation.TotalTime;
        public int RoyalStops { get; set; } = simulation.RoyalStops;
        public decimal AverageWear { get; set; } = simulation.AverageWear;
        public string FinalState { get; set; } = simulation.FinalState;

    }
}
