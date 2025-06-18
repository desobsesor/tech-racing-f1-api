using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Entities.Attributes;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class SimulationRepository(ApplicationDbContext context) : ISimulationRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Simulation?> GetById(int id)
    {
        return await _context.Simulations
            .Include(a => a.Strategy)
            .Include(a => a.Weather)
            .Include(a => a.Track)
            .FirstOrDefaultAsync(a => a.SimulationId == id);
    }
    public async Task<IEnumerable<Simulation>> GetAll()
    {
        return await _context.Simulations
            .Include(a => a.Strategy)
            .Include(a => a.Weather)
            .Include(a => a.Track)
            .ToListAsync();
    }
    public async Task<int> Generate(Simulation simulation)
    {
        _context.Simulations.Add(simulation);
        await _context.SaveChangesAsync();
        return simulation.SimulationId;
    }
    public async Task<int> SaveSimulationAsync(
        List<StrategySimulate> strategies,
        int maxLaps,
        int trackId,
        int weatherId,
        int driverId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // 1. Save main strategy
            var strategy = new Strategy
            {
                StrategyName = $"Strategy_{DateTime.UtcNow:yyyyMMddHHmmss}",
                TotalLaps = maxLaps,
                PlannedStops = strategies.First().TotalStops,
                EstimatedTime = CalculateEstimatedTime(strategies.First()),
                Risk = CalculateRisk(strategies.First()),
                WeatherId = weatherId,
                TrackId = trackId
            };
            await _context.Strategies.AddAsync(strategy);
            await _context.SaveChangesAsync();

            // 2. Save strategy details
            foreach (var stint in strategies.First().Stints)
            {
                await _context.StrategyDetail.AddAsync(new StrategyDetail
                {
                    StrategyId = strategy.StrategyId,
                    TyreId = GetTyreIdByType(stint.Tyre.Name),
                    DriverId = driverId,
                    CurveSegment = await CalculateCurveSegment(stint, trackId),
                    OrderSegment = stint.Tyre.TyreTypeId
                });
            }
            // 3. Save simulation
            var simulation = new Simulation
            {
                StrategyId = strategy.StrategyId,
                ExecutionDate = DateTime.UtcNow,
                WeatherId = weatherId,
                TrackId = trackId,
                TotalTime = CalculateEstimatedTime(strategies.First()),
                RoyalStops = strategies.First().TotalStops,
                AverageWear = (decimal)strategies.First().AveragePerformance,
                FinalState = "Completed"
            };

            await _context.Simulations.AddAsync(simulation);
            await _context.SaveChangesAsync();

            // 4. Save logs (example for 1 simulation)
            for (int lap = 1; lap <= maxLaps; lap++)
            {
                await _context.SimulationLogs.AddAsync(new SimulationLog
                {
                    SimulationId = simulation.SimulationId,
                    Lap = lap,
                    TimeLap = CalculateLapTime(lap, strategies.First()),
                    TyreId = GetTyreIdForLap(lap, strategies.First().Stints),
                    CurrentWear = CalculateWearAtLap(lap, (decimal)strategies.First().AveragePerformance),
                    RemainingFuel = CalculateFuelAtLap(lap, (decimal)strategies.First().AveragePerformance, (decimal)0.01),
                    WeatherId = weatherId
                });
            }
            await _context.SaveChangesAsync();


            await transaction.CommitAsync();

            return simulation.SimulationId;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task<int> CalculateCurveSegment(Stint stint, int trackId)
    {
        // Obtain the curve segment for the current lap through the trackId
        Track track = await _context.Tracks.FirstOrDefaultAsync(t => t.TrackId == trackId) ?? throw new ArgumentException("Invalid trackId");
        // Logic to calculate the curve segment with the number of curves in the track, "tracks.curves"
        int curveSegment = stint.Laps % track.Curves;
        return curveSegment;
    }
    private static decimal CalculateFuelAtLap(int lap, decimal initialFuel, decimal fuelConsumptionPerLap)
    {
        // Calculate remaining fuel based on initial fuel and consumption per lap
        try
        {
            return initialFuel - (lap * fuelConsumptionPerLap);
        }
        catch
        {
            return (decimal)0.0;
        }
    }

    private static decimal CalculateWearAtLap(int lap, decimal wearPerLap)
    {
        // Calculate wear based on wear per lap
        try
        {
            if (wearPerLap.GetType() != typeof(decimal))
            {
                throw new ArgumentException("wearPerLap must be of type decimal");
            }

            decimal result = (decimal)lap * wearPerLap;

            if (result < decimal.MinValue || result > decimal.MaxValue)
            {
                throw new OverflowException("Arithmetic overflow error converting numeric to data type numeric.");
            }

            return result;
        }
        catch (OverflowException)
        {
            throw new OverflowException("Arithmetic overflow error converting numeric to data type numeric.");
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (Exception ex) when (ex is InvalidCastException || ex is FormatException)
        {
            return 0.0m;
        }
        catch
        {
            return 0.0m;
        }
    }
    private static int GetTyreIdForLap(int lap, List<Stint> segments)
    {
        // Determine the tire ID based on the current lap and segment logic
        foreach (var segment in segments)
        {
            if (lap >= segment.Laps && lap <= segment.Tyre?.MaxLaps)
            {
                return segment.Tyre.TyreTypeId;
            }
        }
        // Default to the first segment's tire ID if no match is found
        return segments.FirstOrDefault()?.Tyre?.TyreTypeId ?? -1;
    }
    private static decimal CalculateLapTime(int lap, StrategySimulate strategy)
    {
        // Example: 90 seconds per lap
        return (decimal)(90.0 + (lap * 0.1));// Lap time simulation
    }

    private static int GetTyreIdByType(string type) => type switch
    {
        "Blando" => 1,
        "Medio" => 2,
        "Duro" => 3,
        _ => throw new ArgumentException("Invalid tyre type")
    };
    private static decimal CalculateEstimatedTime(StrategySimulate strategy)
    {
        // Example: 90 seconds per lap * total laps
        return (decimal)(strategy.TotalLaps * 90.0);
    }
    private static decimal CalculateRisk(StrategySimulate strategy)
    {
        // More stops = greater risk
        return (decimal)(strategy.TotalStops * 0.15);
    }
}
