namespace DataCollectionService.Business.Environment.Models;

public class EnvironmentConditions
{
    public string? ShipId { get; set; }
    public string? CompartmentId { get; set; }
    public TemperatureConditions? Temperature { get; set; }
    public HumidityConditions? Humidity { get; set; }
    public LocationConditions? Location { get; set; }
}

public abstract class ConditionsBase
{
    public DateTime TimestampUtc { get; set; }
}

public class TemperatureConditions : ConditionsBase
{
    public double CelsiusDeg { get; set; }
}

public class HumidityConditions : ConditionsBase
{
    public double HumidityVaporGramsPerAirKg { get; set; }
}

public class LocationConditions : ConditionsBase
{
    public double LocationLatitude { get; set; }
    public double LocationLongitude { get; set; }
}