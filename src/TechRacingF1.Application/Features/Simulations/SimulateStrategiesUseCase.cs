using Microsoft.Extensions.Logging;
using TechRacingF1.Application.Features.Simulations.Queries;
using TechRacingF1.Domain.Entities.Attributes;
using TechRacingF1.Domain.Ports;
using TechRacingF1.Domain.Services;

namespace TechRacingF1.Application.Features.Simulations
{
    public class SimulateStrategiesUseCase(
        ITyreRepository tyreRepository,
        IWeatherRepository weatherRepository,
        ITrackRepository trackRepository,
        ISimulationRepository simulationRepository,
        IDriverRepository driverRepository,
        ILogger<SimulateStrategiesUseCase> logger
        )
    {
        public record TyreSegment(string Type, int Laps);
        public record StrategyVariant(IReadOnlyList<TyreSegment> Segments, int TotalStops, double AvgPerformance);
        private readonly TyreStrategyGenerator _generator = new();
        public async Task<(Task<List<StrategySimulate>> listStrategy, int totalStrategy)> Execute(SimulationGenerateDTO request)
        {
            var tyres = await tyreRepository.GetTyreTypesAsync();
            var weather = await weatherRepository.GetById(request.WeatherId);
            var track = await trackRepository.GetById(request.TrackId);
            var driver = await driverRepository.GetById(request.DriverId);
            // Generate valid strategies
            var strategies = _generator.GenerateStrategies(request.MaxLaps, tyres);
            var filterStrategies = new List<StrategySimulate>();

            // Show results
            logger.LogInformation($"Valid strategies for {request.MaxLaps} laps with a climate {weather?.Condition} on the {track?.TrackName} track");
            logger.LogInformation("---------------------------------------------------");

            foreach (var strategy in strategies.Take(10))  // Mostrar primeras 12 estrategias
            {
                logger.LogInformation($"Stops: {strategy.TotalStops} | " +
                                  $"Performance: {strategy.AveragePerformance:F2} | " +
                                  $"Combination: {string.Join(" -> ", strategy.Stints.Select(s => $"{s.Tyre?.Name} ({s.Laps} vueltas)"))}");
                filterStrategies.Add(strategy);
            }
            logger.LogInformation($"\nTotal number of strategies generated: {strategies.Count}");

            var i = await simulationRepository.SaveSimulationAsync(
                strategies,
                request.MaxLaps,
                request.TrackId,
                request.WeatherId,
                request.DriverId
            );
            logger.LogInformation($"\nNew SimulationId generated after save: {i}");
            return (Task.FromResult(filterStrategies), strategies.Count);
        }


    }
}
