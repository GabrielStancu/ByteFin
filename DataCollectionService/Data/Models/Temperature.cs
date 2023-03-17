using System.ComponentModel.DataAnnotations;

namespace DataCollectionService.Business.Models;

public class Temperature : ModelBase
{
    public decimal CelsiusDeg { get; set; }
}
