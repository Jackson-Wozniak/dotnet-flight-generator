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

    private double ToRadians(double coordinate)
    {
        return (Math.PI / 180) * coordinate;
    }

    private double CalculateDistanceMiles()
    {
        const double EarthRadiusMiles = 3958.8;
        var depLatRads = ToRadians(Departure.Latitude);
        var depLongRads = ToRadians(Departure.Longitude);
        var destLatRads = ToRadians(Destination.Latitude);
        var destLongRads = ToRadians(Destination.Longitude);
        
        var latDiff = destLatRads - depLatRads;
        var longDiff = destLongRads - depLongRads;
        
        var a = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
                Math.Cos(depLatRads) * Math.Cos(destLatRads) *
                Math.Sin(longDiff / 2) * Math.Sin(longDiff / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return Math.Round(EarthRadiusMiles * c, 1);
    }

    private String CalculateFlightTime()
    {
        var time = DistanceMiles / (100 * 1.151); //100 knots
        return time.ToString("HH:mm");
    }
}