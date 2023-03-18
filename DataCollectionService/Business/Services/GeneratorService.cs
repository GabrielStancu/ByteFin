using DataCollectionService.Business.Environment;
using DataCollectionService.Data.Entities;
using DataCollectionService.DTOs.Replies;
using DataCollectionService.DTOs.Requests;

namespace DataCollectionService.Business.Services;

public class GeneratorService : IGeneratorService
{
    private readonly IGenerator<Temperature> _temperatureGenerator;
    private readonly IGenerator<Humidity> _humidityGenerator;
    private readonly IGenerator<Location> _locationGenerator;

    public GeneratorService(
        IGenerator<Temperature> temperatureGenerator,
        IGenerator<Humidity> humidityGenerator,
        IGenerator<Location> locationGenerator)
    {
        _temperatureGenerator = temperatureGenerator;
        _humidityGenerator = humidityGenerator;
        _locationGenerator = locationGenerator;
    }

    public EnvironmentConditions? Generate(EnvironmentParamaters parameters)
    {
        if (parameters.ShipId is null || parameters.CompartmentId is null)
            return null;

        var temperature = _temperatureGenerator.Generate(parameters.ShipId, parameters.CompartmentId);
        var humidity = _humidityGenerator.Generate(parameters.ShipId, parameters.CompartmentId);
        var location = _locationGenerator.Generate(parameters.ShipId, parameters.CompartmentId);

        // TODO: store in db

        return CreateConditionsResult(temperature, humidity, location, parameters.ShipId!, parameters.CompartmentId!);
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
