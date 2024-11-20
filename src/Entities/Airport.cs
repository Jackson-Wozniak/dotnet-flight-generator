using System.ComponentModel.DataAnnotations;

namespace backend.Entities;

public class Airport
{
    [Key]
    public string IcaoCode { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Continent { get; set; }
    public string Country { get; set; }

    public static Airport create(string code, string name, double lat, double lon,
        string continent, string country)
    {
        var airport = new Airport();
        airport.IcaoCode = code;
        airport.Name = name;
        airport.Latitude = lat;
        airport.Longitude = lon;
        airport.Continent = continent;
        airport.Country = country;
        return airport;
    }

    public override string ToString()
    {
        return $"{IcaoCode}";
    }
}