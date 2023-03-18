namespace DataCollectionService.Configuration;

public class MeasurementPrefixConfiguration : IMeasurementPrefixConfiguration
{
    public string Humidity { get; set; } = null!;
    public string Temperature { get; set; } = null!;
    public string Location { get; set; } = null!;
}
