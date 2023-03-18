namespace DataCollectionService.Configuration;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TemperatureCollectionName { get; set; } = null!;
    public string HumidityCollectionName { get; set; } = null!;
    public string LocationCollectionName { get; set; } = null!;
    public string ParametersCollectionName { get; set; } = null!;
}
