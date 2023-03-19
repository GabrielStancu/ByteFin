namespace ShipService.Business.Dtos.Requests;

public class CreateShipDto
{
    public string? ShipName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public IEnumerable<string?>? CompartmentNames { get; set; }
}