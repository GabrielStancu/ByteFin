namespace DataCollectionService.Business.Environment.Models;

public class EnvironmentParamaters
{
    public string? ShipId { get; set; }
    public string? CompartmentId { get; set; }
    public MeasurementParameters? TemperatureParameters { get; set; }
    public MeasurementParameters? HumidityParameters { get; set; }
    public LocationParameters? LocationParameters { get; set; }
}

public class LocationParameters : MeasurementParameters
{
    public MeasurementParameters? LongitudeParameters { get; set; }
    public MeasurementParameters? LatitudeParameters { get; set; }
}
