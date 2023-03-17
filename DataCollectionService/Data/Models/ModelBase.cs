using System.ComponentModel.DataAnnotations;

namespace DataCollectionService.Business.Models;

public class ModelBase
{
    [Required]
    public string Id { get; set; } = null!;
    public DateTime TimestampUTC { get; set; }
    public string ShipId { get; set; } = null!;
    public string CompartmentId { get; set; } = null!;
}
