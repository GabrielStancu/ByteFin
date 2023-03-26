using System.Collections.Concurrent;
using AutoMapper;
using ShipService.Contracts.GetShipsInfo;
using ShipService.Data;
using ShipService.Persistence;

namespace ShipService.Business.GetShipsInfo;

public class ShipsInfoService : IShipInfoService
{
    private readonly IShipRepository _shipRepository;
    private readonly ICompartmentRepository _compartmentRepository;
    private readonly IMapper _mapper;

    public ShipsInfoService(IShipRepository shipRepository, ICompartmentRepository compartmentRepository, IMapper mapper)
    {
        _shipRepository = shipRepository;
        _compartmentRepository = compartmentRepository;
        _mapper = mapper;
    }

    public async Task<ShipsInfoResponse> GetShipsInfoAsync()
    {
        var ships = await _shipRepository.GetAllNotDeletedAsync();
        var shipResponses = new ConcurrentBag<ShipResponse>();
        var compartmentTasks = new List<Task>();

        foreach (var ship in ships)
        {
            var compartmentTask = AddShipResponse(ship, shipResponses);
            compartmentTasks.Add(compartmentTask);
        }

        await Task.WhenAll(compartmentTasks);

        var shipsInfoResponse = new ShipsInfoResponse
        {
            Ships = shipResponses
        };

        return shipsInfoResponse;
    }

    private async Task AddShipResponse(Ship ship, ConcurrentBag<ShipResponse> shipResponses)
    {
        if (ship.Id is null)
            return;

        var shipResponse = _mapper.Map<ShipResponse>(ship);
        var shipCompartments = await _compartmentRepository.GetAllShipCompartmentsAsync(ship.Id);

        shipResponse.Compartments = _mapper.Map<IEnumerable<CompartmentResponse>>(shipCompartments);
        shipResponses.Add(shipResponse);
    }
}