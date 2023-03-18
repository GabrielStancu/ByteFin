using DataCollectionService.Business.Environment.Models;
using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;

namespace DataCollectionService.Business.Environment.Generation;

public class LocationGenerator : Generator<Location>
{
    private readonly IMeasurementPrefixConfiguration _configuration;

    public LocationGenerator(IMeasurementPrefixConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override Location Generate(MeasurementParameters parameters, string shipId, string compartmentId)
    {
        if (parameters is not LocationParameters locationParameters)
            throw new ArgumentException($"Provided type is not suitable for generating {nameof(Location)}");

        var latitude = GenerateValue(locationParameters.LatitudeParameters!);
        var longitude = GenerateValue(locationParameters.LongitudeParameters!);
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
