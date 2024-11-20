using backend.Entities;

namespace backend.Services;

public interface IAirportService
{
    Task<bool> ResetAndSaveAirports(List<Airport> airports);
    int AirportCount();
    Task<List<Airport>> GetAirports();
    Task<List<Airport>> RandomAirports();
}