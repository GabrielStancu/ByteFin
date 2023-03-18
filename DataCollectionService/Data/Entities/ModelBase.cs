using System.ComponentModel.DataAnnotations;

namespace DataCollectionService.Data.Entities;

public class ModelBase
{
    [Required]
    public string Id { get; set; } = null!;
    public DateTime TimestampUtc { get; set; }
    public string ShipId { get; set; } = null!;
    public string CompartmentId { get; set; } = null!;
    public bool Deleted { get; set; }
}
