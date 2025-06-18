using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Simulation> Simulations => Set<Simulation>();
        public DbSet<SimulationLog> SimulationLogs => Set<SimulationLog>();
        public DbSet<Strategy> Strategies => Set<Strategy>();
        public DbSet<StrategyDetail> StrategyDetail => Set<StrategyDetail>();
        public DbSet<PitStop> PitStops => Set<PitStop>();
        public DbSet<Weather> Weathers => Set<Weather>();
        public DbSet<Track> Tracks => Set<Track>();
        public DbSet<Tyre> Tyres => Set<Tyre>();
        public DbSet<Driver> Drivers => Set<Driver>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // base.OnModelCreating(modelBuilder);
            // Configuración de las entidades
            // Entity Simulation
            modelBuilder.Entity<Simulation>().HasKey(s => s.SimulationId);
            modelBuilder.Entity<Simulation>().Property(s => s.SimulationId).HasColumnType("int");
            modelBuilder.Entity<Simulation>().Property(s => s.StrategyId).HasColumnType("int");
            modelBuilder.Entity<Simulation>().Property(s => s.ExecutionDate).HasColumnType("datetime2");
            modelBuilder.Entity<Simulation>().Property(s => s.WeatherId).HasColumnType("int");
            modelBuilder.Entity<Simulation>().Property(s => s.TrackId).HasColumnType("int");
            modelBuilder.Entity<Simulation>().Property(s => s.FinalState).HasColumnType("varchar(20)");
            modelBuilder.Entity<Simulation>().Property(s => s.RoyalStops).HasColumnType("int");
            modelBuilder.Entity<Simulation>().Property(s => s.TotalTime).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Simulation>().Property(s => s.AverageWear).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Simulation>().HasOne(e => e.Strategy)
                .WithMany(e => e.Simulations)
                .HasForeignKey(e => e.StrategyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Simulation>().HasOne(e => e.Weather)
                .WithMany(e => e.Simulations)
                .HasForeignKey(e => e.WeatherId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Simulation>().HasOne(e => e.Track)
                .WithMany(e => e.Simulations)
                .HasForeignKey(e => e.TrackId)
                .OnDelete(DeleteBehavior.NoAction);

            // Entity Simulation Logs
            modelBuilder.Entity<SimulationLog>().HasKey(s => s.SimulationLogId);
            modelBuilder.Entity<SimulationLog>().Property(s => s.SimulationLogId).HasColumnType("int");
            modelBuilder.Entity<SimulationLog>().Property(s => s.SimulationId).HasColumnType("int");
            modelBuilder.Entity<SimulationLog>().Property(s => s.Lap).HasColumnType("int");
            modelBuilder.Entity<SimulationLog>().Property(s => s.TimeLap).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<SimulationLog>().Property(s => s.TyreId).HasColumnType("int");
            modelBuilder.Entity<SimulationLog>().Property(s => s.CurrentWear).HasColumnType("decimal(18,5)");
            modelBuilder.Entity<SimulationLog>().Property(s => s.RemainingFuel).HasColumnType("decimal(18,5)");
            modelBuilder.Entity<SimulationLog>().Property(s => s.CreatedAt).HasColumnType("datetime2");
            modelBuilder.Entity<SimulationLog>().HasOne(e => e.Simulation)
                .WithMany(e => e.SimulationLogs)
                .HasForeignKey(e => e.SimulationId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SimulationLog>().HasOne(e => e.Weather)
                .WithMany(e => e.SimulationLogs)
                .HasForeignKey(e => e.WeatherId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SimulationLog>().HasOne(e => e.Tyre)
                .WithMany(e => e.SimulationLogs)
                .HasForeignKey(e => e.TyreId)
                .OnDelete(DeleteBehavior.NoAction);

            // Entity PitStop
            modelBuilder.Entity<PitStop>().HasKey(s => s.PitStopId);
            modelBuilder.Entity<PitStop>().Property(s => s.PitStopId).HasColumnType("int");
            modelBuilder.Entity<PitStop>().Property(s => s.Lap).HasColumnType("int");
            modelBuilder.Entity<PitStop>().Property(s => s.TimeSeconds).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PitStop>().HasOne(e => e.Strategy)
                .WithMany(e => e.PitStops)
                .HasForeignKey(e => e.StrategyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PitStop>().HasOne(e => e.PreviousTyre)
                .WithMany(e => e.PitStopsPreviousTyre)
                .HasForeignKey(e => e.PreviousTyreId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PitStop>().HasOne(e => e.NewTyre)
                .WithMany(e => e.PitStopsNewTyre)
                .HasForeignKey(e => e.NewTyreId)
                .OnDelete(DeleteBehavior.NoAction);

            // Entity Driver
            modelBuilder.Entity<Driver>().HasKey(s => s.DriverId);
            modelBuilder.Entity<Driver>().Property(s => s.DriverId).HasColumnType("int");
            modelBuilder.Entity<Driver>().Property(s => s.Fullname).HasColumnType("varchar(50)");
            modelBuilder.Entity<Driver>().Property(s => s.Team).HasColumnType("varchar(80)");
            modelBuilder.Entity<Driver>().Property(s => s.Nationality).HasColumnType("varchar(20)");
            modelBuilder.Entity<Driver>().Property(s => s.DriverLevel).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Driver>().Property(s => s.Truculence).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Driver>().Property(s => s.Experience).HasColumnType("int");

            // Entity Strategy
            modelBuilder.Entity<Strategy>().HasKey(s => s.StrategyId);
            modelBuilder.Entity<Strategy>().Property(s => s.StrategyId).HasColumnType("int");
            modelBuilder.Entity<Strategy>().Property(s => s.StrategyName).HasColumnType("varchar(50)");
            modelBuilder.Entity<Strategy>().Property(s => s.TotalLaps).HasColumnType("int");
            modelBuilder.Entity<Strategy>().Property(s => s.PlannedStops).HasColumnType("int");
            modelBuilder.Entity<Strategy>().Property(s => s.EstimatedTime).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Strategy>().Property(s => s.Risk).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Strategy>().HasOne(e => e.Weather)
                .WithMany(e => e.Strategies)
                .HasForeignKey(e => e.WeatherId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Strategy>().HasOne(e => e.Track)
                .WithMany(e => e.Strategies)
                .HasForeignKey(e => e.TrackId)
                .OnDelete(DeleteBehavior.NoAction);

            // Entity Track
            modelBuilder.Entity<Track>().HasKey(s => s.TrackId);
            modelBuilder.Entity<Track>().Property(s => s.TrackId).HasColumnType("int");
            modelBuilder.Entity<Track>().Property(s => s.TrackName).HasColumnType("varchar(50)");
            modelBuilder.Entity<Track>().Property(s => s.Country).HasColumnType("varchar(50)");
            modelBuilder.Entity<Track>().Property(s => s.TrackLength).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Track>().Property(s => s.Curves).HasColumnType("int");
            modelBuilder.Entity<Track>().Property(s => s.AsphaltType).HasColumnType("varchar(20)");
            modelBuilder.Entity<Track>().Property(s => s.TyreWear).HasColumnType("decimal(18,2)");

            // Entity Weather
            modelBuilder.Entity<Weather>().HasKey(s => s.WeatherId);
            modelBuilder.Entity<Weather>().Property(s => s.WeatherId).HasColumnType("int");
            modelBuilder.Entity<Weather>().Property(s => s.Condition).HasColumnType("varchar(20)");
            modelBuilder.Entity<Weather>().Property(s => s.Humidity).HasColumnType("int");
            modelBuilder.Entity<Weather>().Property(s => s.Temperature).HasColumnType("int");
            modelBuilder.Entity<Weather>().Property(s => s.RiskFactor).HasColumnType("decimal(18,2)");

            // Entity Tyre
            modelBuilder.Entity<Tyre>().HasKey(s => s.TyreId);
            modelBuilder.Entity<Tyre>().Property(s => s.TyreId).HasColumnType("int");
            modelBuilder.Entity<Tyre>().Property(s => s.TyreType).HasColumnType("varchar(20)");
            modelBuilder.Entity<Tyre>().Property(s => s.Quality).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tyre>().Property(s => s.BaseDegradation).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tyre>().Property(s => s.SpeedKmh).HasColumnType("int");

            // Entity Strategy Detail
            modelBuilder.Entity<StrategyDetail>().HasKey(s => s.StrategyDetailId);
            modelBuilder.Entity<StrategyDetail>().Property(s => s.StrategyDetailId).HasColumnType("int");
            modelBuilder.Entity<StrategyDetail>().Property(s => s.CurveSegment).HasColumnType("int");
            modelBuilder.Entity<StrategyDetail>().Property(s => s.OrderSegment).HasColumnType("int");
            modelBuilder.Entity<StrategyDetail>().HasOne(e => e.Strategy)
                .WithMany(e => e.StrategyDetails)
                .HasForeignKey(e => e.StrategyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StrategyDetail>().HasOne(e => e.Tyre)
                .WithMany(e => e.StrategyDetails)
                .HasForeignKey(e => e.TyreId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StrategyDetail>().HasOne(e => e.Driver)
                .WithMany(e => e.StrategyDetails)
                .HasForeignKey(e => e.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                              .HaveColumnType("datetime2");
        }


    }
}
