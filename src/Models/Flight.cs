using backend.Dto;
using backend.Entities;

namespace backend.Models;

public class Flight
{
    public Airport Departure { get; set; }
    public Airport Destination { get; set; }
    public double DistanceMiles { get; set; }
    public string FlightTime { get; set; }

    private Flight(Airport departure, Airport destination)
    {
        Departure = departure;
        Destination = destination;
        DistanceMiles = CalculateDistanceMiles();
        FlightTime = DateTime.Now.ToString("HH:mm:ss");
    }

    public static Flight Create(Airport departure, Airport destination)
    {
        return new Flight(departure, destination);
    }

    public double CalculateDistanceMiles()
    {
        return 1000.0;
    }
}