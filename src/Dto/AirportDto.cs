using backend.Entities;

namespace backend.Dto;

public class AirportDto
{
    public string IcaoCode { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Continent { get; set; }
    public string Country { get; set; }

    public AirportDto(Airport airport)
    {
        IcaoCode = airport.IcaoCode;
        Name = airport.Name;
        Latitude = airport.Latitude;
        Longitude = airport.Longitude;
        Continent = airport.Continent;
        Country = airport.Country;
    }
}