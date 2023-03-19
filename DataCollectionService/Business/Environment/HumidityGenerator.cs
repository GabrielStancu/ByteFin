using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;
using DataCollectionService.Repositories;

namespace DataCollectionService.Business.Environment;

public class HumidityGenerator : Generator<Humidity>
{
    private readonly IGenericRepository<Humidity> _humidityRepository;
    private readonly MeasurementPrefixConfiguration _configuration;
    private readonly AllowedValuesConfiguration _allowedValues;

    public HumidityGenerator(IGenericRepository<Humidity> humidityRepository,
        MeasurementPrefixConfiguration measurementPrefix,
        AllowedValuesConfiguration allowedValues)
    {
        _humidityRepository = humidityRepository;
        _configuration = measurementPrefix;
        _allowedValues = allowedValues;
    }

    public override async Task<Humidity> GenerateAsync(string shipId, string compartmentId)
    {
        var lastOccurrence = await _humidityRepository.GetLastOccurrenceAsync();
        var vaporGramsPerAirKg = GenerateValue(lastOccurrence?.VaporGramsPerAirKg, _allowedValues.MinHumidity, _allowedValues.MaxHumidity);
        var timestamp = CurrentTime;

        return new Humidity
        {
            Id = GenerateId(_configuration.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            VaporGramsPerAirKg = vaporGramsPerAirKg
        };
    }
}
