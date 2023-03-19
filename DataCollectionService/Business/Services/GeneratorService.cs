using DataCollectionService.Business.Environment;
using DataCollectionService.Data.Entities;
using DataCollectionService.DTOs.Replies;
using DataCollectionService.DTOs.Requests;
using DataCollectionService.Repositories;

namespace DataCollectionService.Business.Services;

public class GeneratorService : IGeneratorService
{
    private readonly IGenerator<Temperature> _temperatureGenerator;
    private readonly IGenerator<Humidity> _humidityGenerator;
    private readonly IGenerator<Location> _locationGenerator;
    private readonly IGenericRepository<Temperature> _temperatureRepository;
    private readonly IGenericRepository<Humidity> _humidityRepository;
    private readonly IGenericRepository<Location> _locationRepository;

    public GeneratorService(
        IGenerator<Temperature> temperatureGenerator,
        IGenerator<Humidity> humidityGenerator,
        IGenerator<Location> locationGenerator,
        IGenericRepository<Temperature> temperatureRepository,
        IGenericRepository<Humidity> humidityRepository,
        IGenericRepository<Location> locationRepository)
    {
        _temperatureGenerator = temperatureGenerator;
        _humidityGenerator = humidityGenerator;
        _locationGenerator = locationGenerator;
        _temperatureRepository = temperatureRepository;
        _humidityRepository = humidityRepository;
        _locationRepository = locationRepository;
    }

    public async Task<EnvironmentConditions?> GenerateAsync(EnvironmentParamaters parameters)
    {
        if (parameters.ShipId is null || parameters.CompartmentId is null)
            return null;

        var temperature = await _temperatureGenerator.GenerateAsync(parameters.ShipId, parameters.CompartmentId);
        var humidity = await _humidityGenerator.GenerateAsync(parameters.ShipId, parameters.CompartmentId);
        var location = await _locationGenerator.GenerateAsync(parameters.ShipId, parameters.CompartmentId);
        var environmentConditions = CreateConditionsResult(temperature, humidity, location, parameters.ShipId!, parameters.CompartmentId!);

        await StoreConditionsAsync(temperature, humidity, location);

        return environmentConditions;
    }

    private async Task StoreConditionsAsync(Temperature temperature, Humidity humidity, Location location)
    {
        var tasks = new List<Task>();
        var temperatureTask = _temperatureRepository.SaveAsync(temperature);
        var humidityTask = _humidityRepository.SaveAsync(humidity);
        var locationTask = _locationRepository.SaveAsync(location);

        tasks.Add(temperatureTask);
        tasks.Add(humidityTask);
        tasks.Add(locationTask);

        await Task.WhenAll(tasks);
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
