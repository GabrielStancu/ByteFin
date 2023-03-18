namespace DataCollectionService.Configuration;

public interface IDatabaseConfiguration
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string TemperatureCollectionName { get; set; }
    string HumidityCollectionName { get; set; }
    string LocationCollectionName { get; set; }
    string ParametersCollectionName { get; set; }
}
