using backend.Entities;
using CsvHelper.Configuration;

namespace backend.Utils;

public class AirportRecordMapper : ClassMap<Airport>
{
    public AirportRecordMapper()
    {
        Map(a => a.IcaoCode).Index(0);
        Map(a => a.Name).Index(2);
        Map(a => a.Latitude).Index(3);
        Map(a => a.Longitude).Index(4);
        Map(a => a.Continent).Index(5);
        Map(a => a.Country).Index(6);
    }
}