using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;
using DataCollectionService.Repositories;

namespace DataCollectionService.Business.Environment;

public class LocationGenerator : Generator<Location>
{
    private readonly IGenericRepository<Location> _locationRepository;
    private readonly MeasurementPrefixConfiguration _configuration;
    private readonly AllowedValuesConfiguration _allowedValues;

    public LocationGenerator(IGenericRepository<Location> locationRepository,
        MeasurementPrefixConfiguration measurementPrefix,
        AllowedValuesConfiguration allowedValues)
    {
        _locationRepository = locationRepository;
        _configuration = measurementPrefix;
        _allowedValues = allowedValues;
    }

    public override async Task<Location> GenerateAsync(string shipId, string compartmentId)
    {
        var lastOccurrence = await _locationRepository.GetLastOccurrenceAsync();
        var latitude = GenerateValue(lastOccurrence?.Latitude, _allowedValues.MinLatitude, _allowedValues.MaxLatitude);
        var longitude = GenerateValue(lastOccurrence?.Longitude, _allowedValues.MinLongitude, _allowedValues.MaxLongitude);
        var timestamp = CurrentTime;

        return new Location
        {
            Id = GenerateId(_configuration.Humidity, shipId, compartmentId, timestamp),
            ShipId = shipId,
            CompartmentId = compartmentId,
            TimestampUtc = timestamp,
            Deleted = false,
            Latitude = latitude,
            Longitude = longitude
        };
    }
}
