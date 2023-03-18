namespace DataCollectionService.Configuration;

public interface IAllowedValuesConfiguration
{
    double MinTemperature { get; set; }
    double MaxTemperature { get; set; }
    double MinHumidity { get; set; }
    double MaxHumidity { get; set; }
    double MinLongitude { get; set; }
    double MaxLongitude { get; set; }
    double MinLatitude { get; set; }
    double MaxLatitude { get; set; }
}
