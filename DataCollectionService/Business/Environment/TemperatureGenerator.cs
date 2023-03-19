using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;
using DataCollectionService.Repositories;

namespace DataCollectionService.Business.Environment;

public class TemperatureGenerator : Generator<Temperature>
{
    private readonly IGenericRepository<Temperature> _temperatureRepository;
    private readonly MeasurementPrefixConfiguration _measurementPrefix;
    private readonly AllowedValuesConfiguration _allowedValues;

    public TemperatureGenerator(IGenericRepository<Temperature> temperatureRepository,
        MeasurementPrefixConfiguration measurementPrefix,
        AllowedValuesConfiguration allowedValues)
    {
        _temperatureRepository = temperatureRepository;
        _measurementPrefix = measurementPrefix;
        _allowedValues = allowedValues;
    }

    public override async Task<Temperature> GenerateAsync(string shipId, string compartmentId)
    {
        var lastOccurrence = await _temperatureRepository.GetLastOccurrenceAsync();
        var celsiusDeg = GenerateValue(lastOccurrence?.CelsiusDeg, _allowedValues.MinTemperature, _allowedValues.MaxTemperature);
        var timestamp = CurrentTime;

        return new Temperature
        {
            Id = GenerateId(_measurementPrefix.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            CelsiusDeg = celsiusDeg
        };
    }
}
