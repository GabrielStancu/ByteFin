using System.Collections.Concurrent;
using ShipService.Business.Dtos.Replies;
using ShipService.Data.Models;
using ShipService.Data.Repositories;

namespace ShipService.Business.Services;

public class ShipCompartmentsCollector : IShipCompartmentsCollector
{
    private readonly IGenericRepository<Ship> _shipRepository;
    private readonly ICompartmentRepository _compartmentRepository;

    public ShipCompartmentsCollector(IGenericRepository<Ship> shipRepository, ICompartmentRepository compartmentRepository)
    {
        _shipRepository = shipRepository;
        _compartmentRepository = compartmentRepository;
    }

    public async Task<IEnumerable<ShipCompartmentsDto>> GetCompartmentsAsync()
    {
        var ships = await _shipRepository.GetAllAsync();
        var shipIds = ships?.Select(s => s?.Id).ToList();

        if (shipIds is null || !shipIds.Any())
            return Enumerable.Empty<ShipCompartmentsDto>();

        var getCompartmentsTasks = new List<Task>();
        var shipCompartments = new ConcurrentBag<ShipCompartmentsDto>();

        foreach (var shipId in shipIds)
        {
            var getCompartmentsTask = GetShipCompartmentsAsync(shipCompartments, shipId!);
            getCompartmentsTasks.Add(getCompartmentsTask);
        }

        await Task.WhenAll(getCompartmentsTasks);

        return shipCompartments;
    }

    private async Task GetShipCompartmentsAsync(ConcurrentBag<ShipCompartmentsDto> shipCompartments, string shipId)
    {
        var compartments = await _compartmentRepository.GetAllShipCompartmentsAsync(shipId);
        var shipWithCompartments = new ShipCompartmentsDto
        {
            ShipId = shipId,
            CompartmentIds = compartments.Select(c => c.Id)
        };

        shipCompartments.Add(shipWithCompartments);
    }
}