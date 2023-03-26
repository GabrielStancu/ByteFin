namespace ShipService.Configuration;

public class DatabaseConfiguration
{
    public const string SectionName = "Database";
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ShipCollectionName { get; set; } = null!;
    public string CompartmentCollectionName { get; set; } = null!;
}