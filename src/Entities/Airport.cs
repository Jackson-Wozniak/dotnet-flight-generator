namespace backend.Entities;

public class Airport
{
    public string IcaoCode { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Continent { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"{IcaoCode}";
    }
}