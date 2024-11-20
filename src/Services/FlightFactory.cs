using backend.Models;

namespace backend.Services;

public class FlightFactory
{
    private readonly IAirportService _airportService;

    public FlightFactory(IAirportService airportService)
    {
        _airportService = airportService;
    }
    
    public Flight Generate()
    {
        var airports = _airportService.RandomAirports().Result;
        return Flight.Create(airports[0], airports[0]);
    }
}