namespace DataCollectionService.Data;

public class DatabaseSettings : IDatabaseSettings
{
    public string DatabaseName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string HumidityCollectioName { get; set; } = string.Empty;
    public string LocationollectioName { get; set; } = string.Empty;
    public string TemperatureCollectioName { get; set; } = string.Empty;
}
