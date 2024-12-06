using backend.Exceptions;
using backend.Models;

namespace backend.Services;

public class FlightFactory
{
    private readonly IAirportService _airportService;
    private static Random random = new Random();
    private const int MaxAllowedDistance = 10000;

    public FlightFactory(IAirportService airportService)
    {
        _airportService = airportService;
    }
    
    public Flight Generate()
    {
        var airports = _airportService.RandomAirports().Result;
        return Flight.Create(airports[0], airports[0]);
    }
    
    public Flight Generate(double maxDistance)
    {
        if (maxDistance > MaxAllowedDistance) throw new FlightGeneratorException("must be under 10,000 miles");
        /*
         TODO:
            we want to define some type of max distance that is allowed to be requested (minimize loop error)
            
            another approach to this is:
                query to get a random airport in the list as departure
                then filter to only include other airports that are within maxDistance
                pick any one of those that are within the range
         */
        var airports = _airportService.GetAirports().Result;

        //there just needs to be some way to ensure we dont infinitely check if its not possible with distance
        for (var i = 0; i < 1000; i++)
        {
            var rand1 = random.Next(0, airports.Count - 1);
            var rand2 = random.Next(0, airports.Count - 1);
            if (rand1 == rand2) continue;

            var flight = Flight.Create(airports[rand1], airports[rand2]);
            if (flight.DistanceMiles <= maxDistance) return flight;
        }
        
        throw new FlightGeneratorException("could not find a route within distance");
    }
}