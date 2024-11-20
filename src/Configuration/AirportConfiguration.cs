using System.Globalization;
using backend.Entities;
using backend.Services;
using backend.Utils;
using CsvHelper;
using CsvHelper.Configuration;

namespace backend.Configuration;

public class AirportConfiguration : IHostedService
{
    private static readonly int DEFAULT_AIRPORT_COUNT = 44303;
    private static readonly string AIRPORT_PATH = "App_Data/Airports.csv";
    private readonly IServiceProvider _serviceProvider;

    public AirportConfiguration(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        InitializeAirports();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void InitializeAirports()
    {
        using (var reader = new StreamReader(AIRPORT_PATH))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.Context.RegisterClassMap<AirportRecordMapper>();
            
            var records = csv.GetRecords<Airport>().ToList();

            using (var scope = _serviceProvider.CreateScope())
            {
                var airportService = scope.ServiceProvider.GetRequiredService<IAirportService>();

                if (airportService.AirportCount() != DEFAULT_AIRPORT_COUNT)
                {
                    Console.WriteLine("Saving airports from Airports.csv");
                    airportService.ResetAndSaveAirports(records).Wait();
                }
            }
        }
    }
}