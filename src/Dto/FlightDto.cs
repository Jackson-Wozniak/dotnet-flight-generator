using backend.Models;

namespace backend.Dto;

public class FlightDto
{
    public AirportDto Departure { get; set; }
    public AirportDto Destination { get; set; }
    public double DistanceMiles { get; set; }
    public string FlightTime { get; set; }

    public FlightDto(Flight flight)
    {
        Departure = new AirportDto(flight.Departure);
        Destination = new AirportDto(flight.Destination);
        DistanceMiles = flight.DistanceMiles;
        FlightTime = flight.FlightTime;
    }
}