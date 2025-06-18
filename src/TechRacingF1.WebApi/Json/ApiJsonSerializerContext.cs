using System.Text.Json.Serialization;
using TechRacingF1.Application.Features.Simulations.Queries;
using TechRacingF1.Application.Features.Strategies.Queries;
using TechRacingF1.Application.Features.StrategyDetails.Queries;
using TechRacingF1.Application.Features.Tracks.Queries;
using TechRacingF1.Application.Features.Weathers.Queries;
using TechRacingF1.Application.Features.Drivers.Queries;
using TechRacingF1.Domain.Entities.Attributes;

namespace TechRacingF1.WebApi.Json
{
    /// <summary>
    /// JSON serializer context for API responses
    /// This class provides source generation for System.Text.Json when using AOT compilation
    /// </summary>
    [JsonSerializable(typeof(object))]
    [JsonSerializable(typeof(Exception))]
    [JsonSerializable(typeof(Dictionary<string, object>))]
    [JsonSerializable(typeof(Dictionary<string, string>))]
    // Anonymous type used in error responses
    [JsonSerializable(typeof(ErrorResponse))]
    // DTOs for Simulation feature
    [JsonSerializable(typeof(StrategySimulateDTO))]
    [JsonSerializable(typeof(StrategySimulate))]
    [JsonSerializable(typeof(List<StrategySimulate>))]
    [JsonSerializable(typeof(Task<List<StrategySimulate>>))]
    [JsonSerializable(typeof(StintDTO))]
    [JsonSerializable(typeof(Stint))]
    [JsonSerializable(typeof(TyreTypeDTO))]
    [JsonSerializable(typeof(TyreType))]
    // DTOs for Simulation feature
    [JsonSerializable(typeof(StrategyDetailDTO))]
    [JsonSerializable(typeof(List<StrategyDetailDTO>))]
    [JsonSerializable(typeof(SimulationDTO))]
    [JsonSerializable(typeof(List<SimulationDTO>))]
    [JsonSerializable(typeof(StrategyDTO))]
    [JsonSerializable(typeof(List<StrategyDTO>))]
    [JsonSerializable(typeof(WeatherDTO))]
    [JsonSerializable(typeof(List<WeatherDTO>))]
    [JsonSerializable(typeof(TrackDTO))]
    [JsonSerializable(typeof(List<TrackDTO>))]
    [JsonSerializable(typeof(DriverDTO))]
    [JsonSerializable(typeof(List<DriverDTO>))]
    public partial class ApiJsonSerializerContext : JsonSerializerContext
    {
    }

    /// <summary>
    /// Standard error response structure
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Request ID for tracking
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Additional message
        /// </summary>
        public string? Message { get; set; }
    }
}