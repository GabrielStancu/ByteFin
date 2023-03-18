using System.ComponentModel.DataAnnotations;

namespace DataCollectionService.Business.Models;

public class Temperature : ModelBase
{
    public double CelsiusDeg { get; set; }
}
