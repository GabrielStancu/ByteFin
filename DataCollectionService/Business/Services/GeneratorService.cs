using DataCollectionService.Business.Environment;
using DataCollectionService.Data.Entities;
using DataCollectionService.DTOs.Replies;
using DataCollectionService.DTOs.Requests;

namespace DataCollectionService.Business.Services;

public class GeneratorService : IGeneratorService
{
    private readonly IGenerator<Temperature> _temperatureGenerator;
    private readonly IGenerator<Humidity> _humiditygenerator;
    private readonly IGenerator<Location> _locationGenerator;

    public GeneratorService(
        IGenerator<Temperature> temperatureGenerator,
        IGenerator<Humidity> humiditygenerator,
        IGenerator<Location> locationGenerator)
    {
        _temperatureGenerator = temperatureGenerator;
        _humiditygenerator = humiditygenerator;
        _locationGenerator = locationGenerator;
    }

    public EnvironmentConditions? Generate(EnvironmentParamaters paramaters)
    {
        if (paramaters is null || paramaters.ShipId is null || paramaters.CompartmentId is null)
            return null;

        var temperature = _temperatureGenerator.Generate(paramaters.ShipId, paramaters.CompartmentId);
        var humidity = _humiditygenerator.Generate(paramaters.ShipId, paramaters.CompartmentId);
        var location = _locationGenerator.Generate(paramaters.ShipId, paramaters.CompartmentId);

        // TODO: store in db

        return CreateConditionsResult(temperature, humidity, location, paramaters.ShipId!, paramaters.CompartmentId!);
    }

    private static EnvironmentConditions CreateConditionsResult(Temperature temperature, Humidity humidity, Location location, string shipId, string compartmentId)
        => new()
        {
            ShipId = shipId,
            CompartmentId = compartmentId,
            Temperature = new TemperatureConditions
            {
                CelsiusDeg = temperature.CelsiusDeg,
                TimestampUtc = temperature.TimestampUtc
            },
            Humidity = new HumidityConditions
            {
                HumidityVaporGramsPerAirKg = humidity.VaporGramsPerAirKg,
                TimestampUtc = humidity.TimestampUtc
            },
            Location = new LocationConditions
            {
                LocationLatitude = location.Latitude,
                LocationLongitude = location.Longitude,
                TimestampUtc = location.TimestampUtc
            }
        };
}
