using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace backend.Configuration;

public class AirportConfiguration : IHostedService
{
    private static readonly string AIRPORT_PATH = "App_Data/Airports.csv";
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        InitializeAirports();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static void InitializeAirports()
    {
        // using (var reader = new StreamReader(AIRPORT_PATH))
        // using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        // {
        //     var records = csv.GetRecords<dynamic>().ToList();
        //
        //     foreach (var record in records)
        //     {
        //         Console.WriteLine(record);
        //     }
        // }
    }
}