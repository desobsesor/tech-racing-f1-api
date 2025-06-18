using Microsoft.VisualBasic;
using TechRacingF1.Domain.Entities.Attributes;

namespace TechRacingF1.Domain.Services
{
    public class TyreStrategyGenerator
    {
        /// <summary>
        /// Generate strategies (synchronous version)
        /// </summary>
        /// <param name="maxLaps"></param>
        /// <param name="tyreTypes"></param>
        /// <returns></returns>
        public List<StrategySimulate> GenerateStrategies(int maxLaps, List<TyreType> tyreTypes)
        {
            // Increase thread pool min threads to avoid starvation
            ThreadPool.SetMinThreads(Environment.ProcessorCount * 2, Environment.ProcessorCount);

            // Add small delay to allow thread pool to process other requests
            Thread.Sleep(100);

            var validStrategies = new List<StrategySimulate>();

            // Generate strategies with different number of stints (prioritizing fewer stops)
            for (int stintCount = 1; stintCount <= 5; stintCount++) // Maximum 5 stints
            {
                // Add small delay between iterations to prevent thread pool starvation
                if (stintCount > 1) Thread.Sleep(50);

                GenerateStintCombinations(new StrategySimulate(), 0, stintCount, maxLaps, tyreTypes, validStrategies);
            }

            // Sort by priorities: 1. Fewer stops, 2. Higher performance
            return [.. validStrategies
                .OrderBy(s => s.TotalStops)
                .ThenByDescending(s => s.AveragePerformance)];
        }

        private void GenerateStintCombinations(
            StrategySimulate currentStrategy,
            int currentLaps,
            int targetStints,
            int maxLaps,
            List<TyreType> tyreTypes,
            List<StrategySimulate> validStrategies)
        {
            // Base case: complete strategy
            if (currentStrategy.Stints.Count == targetStints)
            {
                if (currentLaps == maxLaps)
                {
                    validStrategies.Add(new StrategySimulate
                    {
                        Stints = [..currentStrategy.Stints.Select(s => new Stint
                        {
                            Tyre = s.Tyre,
                            Laps = s.Laps
                        })]
                    });
                }
                return;
            }

            foreach (var tyre in tyreTypes)
            {
                // Calculate available laps for this stint
                int remainingLaps = maxLaps - currentLaps;
                int lapsForStint = Math.Min(tyre.MaxLaps, remainingLaps);

                // Consider only significant stints (minimum 3 laps)
                if (lapsForStint < 3) continue;

                // Try different stint lengths
                for (int laps = lapsForStint; laps >= 3; laps--)
                {
                    // Calculate remaining laps after this stint
                    int newTotalLaps = currentLaps + laps;
                    int remainingAfterStint = maxLaps - newTotalLaps;

                    // Check if it is possible to complete the strategy
                    int remainingStints = targetStints - currentStrategy.Stints.Count - 1;
                    if (remainingAfterStint < remainingStints * 3) continue;  // Each stint minimum 3 laps

                    // Create new stint
                    var newStint = new Stint { Tyre = tyre, Laps = laps };

                    // Clone current strategy and add new stint
                    var newStrategy = new StrategySimulate
                    {
                        Stints = [.. currentStrategy.Stints, newStint]
                    };

                    //Recursive call
                    GenerateStintCombinations(
                        newStrategy,
                        newTotalLaps,
                        targetStints,
                        maxLaps,
                        tyreTypes,
                        validStrategies);
                }
            }
        }

    }
}
