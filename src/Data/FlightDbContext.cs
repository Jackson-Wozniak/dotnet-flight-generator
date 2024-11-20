using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class FlightDbContext : DbContext
{
    public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options) { }
    
    public DbSet<Airport> Airports { get; set; }
}