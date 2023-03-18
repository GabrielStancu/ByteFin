namespace DataCollectionService.Configuration;

public class AllowedValuesConfiguration : IAllowedValuesConfiguration
{
    public double MinTemperature { get; set; }
    public double MaxTemperature { get; set; }
    public double MinHumidity { get; set; }
    public double MaxHumidity { get; set; }
    public double MinLongitude { get; set; }
    public double MaxLongitude { get; set; }
    public double MinLatitude { get; set; }
    public double MaxLatitude { get; set; }
}
