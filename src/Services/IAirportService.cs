using backend.Entities;

namespace backend.Services;

public interface IAirportService
{
    Task<bool> SaveAirport(Airport airport);
    Task<bool> ResetAndSaveAirports(List<Airport> airports);
    int AirportCount();
}