namespace DataCollectionService.Data;

public interface IDatabaseSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
    public string HumidityCollectioName { get; set; }
    public string LocationollectioName { get; set; }
    public string TemperatureCollectioName { get; set; }
}
