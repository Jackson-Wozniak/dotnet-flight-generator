using backend.Entities;
using backend.Models;
using Xunit;

namespace tests.Data;

public class FlightTests
{
    private const double KmhtToKjfkDistance = 198.8;
    private static readonly Airport Kmht = Airport.Create("KHMT", "Manchester Boston Regional", 
        42.9297, 71.4352, "NA", "USA");
    private static readonly Airport Kjfk = Airport.Create("KFJK", "John F. Kennedy International", 
        40.6446, 73.7797, "NA", "USA");
    
    
    [Fact]
    public void FlightDistanceCorrect()
    {
        var kmhtToKjfk = Flight.Create(Kmht, Kjfk);
        var kjfkToKmht = Flight.Create(Kjfk, Kmht);
        
        Assert.Equal(kmhtToKjfk.DistanceMiles, kjfkToKmht.DistanceMiles);
        Assert.Equal(KmhtToKjfkDistance, kmhtToKjfk.DistanceMiles);
    }
}