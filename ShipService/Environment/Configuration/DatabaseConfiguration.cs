namespace ShipService.Environment.Configuration;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ShipCollectionName { get; set; } = null!;
    public string CompartmentCollectionName { get; set; } = null!;
}