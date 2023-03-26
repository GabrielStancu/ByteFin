using System.Collections.Concurrent;
using ShipService.Contracts.RequireShipCondition;
using ShipService.Persistence;

namespace ShipService.Business.RequireShipConditions;

public class ShipCompartmentsCollector : IShipCompartmentsCollector
{
    private readonly IShipRepository _shipRepository;
    private readonly ICompartmentRepository _compartmentRepository;

    public ShipCompartmentsCollector(IShipRepository shipRepository, ICompartmentRepository compartmentRepository)
    {
        _shipRepository = shipRepository;
        _compartmentRepository = compartmentRepository;
    }

    public async Task<IEnumerable<ShipCompartmentsResponse>> GetCompartmentsAsync()
    {
        var ships = await _shipRepository.GetAllAsync();
        var shipIds = ships?.Select(s => s?.Id).ToList();

        if (shipIds is null || !shipIds.Any())
            return Enumerable.Empty<ShipCompartmentsResponse>();

        var getCompartmentsTasks = new List<Task>();
        var shipCompartments = new ConcurrentBag<ShipCompartmentsResponse>();

        foreach (var shipId in shipIds)
        {
            var getCompartmentsTask = GetShipCompartmentsAsync(shipCompartments, shipId!);
            getCompartmentsTasks.Add(getCompartmentsTask);
        }

        await Task.WhenAll(getCompartmentsTasks);

        return shipCompartments;
    }

    private async Task GetShipCompartmentsAsync(ConcurrentBag<ShipCompartmentsResponse> shipCompartments, string shipId)
    {
        var compartments = await _compartmentRepository.GetAllShipCompartmentsAsync(shipId);
        var shipWithCompartments = new ShipCompartmentsResponse
        {
            ShipId = shipId,
            CompartmentIds = compartments.Select(c => c.Id)
        };

        shipCompartments.Add(shipWithCompartments);
    }
}