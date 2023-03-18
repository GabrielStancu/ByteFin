namespace DataCollectionService.Configuration;

public interface IMeasurementPrefixConfiguration
{
    public string Humidity { get; set; }
    public string Temperature { get; set; }
    public string Location { get; set; }
}
