using backend.Data;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class AirportService : IAirportService
{
    private readonly FlightDbContext _flightDbContext;

    public AirportService(FlightDbContext flightDbContext)
    {
        _flightDbContext = flightDbContext;
    }

    public async Task<bool> ResetAndSaveAirports(List<Airport> airports)
    {
        using (var transaction = _flightDbContext.Database.BeginTransaction())
        {
            try
            {
                _flightDbContext.Airports.RemoveRange(_flightDbContext.Airports);
                await _flightDbContext.SaveChangesAsync();
                await _flightDbContext.Airports.AddRangeAsync(airports);
                await _flightDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }

    public Task<List<Airport>> GetAirports()
    {
        return _flightDbContext.Airports.ToListAsync();
    }

    public async Task<List<Airport>> RandomAirports()
    {
        var airports = await _flightDbContext.Airports.ToListAsync();
        
        if (airports.Count < 2)
        {
            //throw FlightGeneratorException
        }
        
        var randomAirports = airports.OrderBy(_ => Guid.NewGuid()).Take(2).ToList();

        return randomAirports;
    }

    public int AirportCount()
    {
        return _flightDbContext.Airports.Count();
    }
}