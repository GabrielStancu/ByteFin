using ShipService.Business.Dtos.Requests;
using ShipService.Data.Models;
using ShipService.Data.Repositories;
using ShipService.Environment.Configuration;

namespace ShipService.Business.Services;

public class ShipCreator : IShipCreator
{
    private readonly IGenericRepository<Ship> _shipRepository;
    private readonly ICompartmentRepository _compartmentRepository;
    private readonly PrefixesConfiguration _prefixesConfig;

    public ShipCreator(IGenericRepository<Ship> shipRepository, ICompartmentRepository compartmentRepository, PrefixesConfiguration prefixesConfig)
    {
        _shipRepository = shipRepository;
        _compartmentRepository = compartmentRepository;
        _prefixesConfig = prefixesConfig;
    }

    public async Task CreateShipWithCompartmentsAsync(CreateShipDto createShipDto)
    {
        if (createShipDto.CompartmentNames is null || !createShipDto.CompartmentNames.Any() || string.IsNullOrEmpty(createShipDto.ShipName))
            return;

        var shipId = $"{_prefixesConfig.Ship}_{createShipDto.ShipName}";
        var tasks = new List<Task>();
        var crateShipTask = CreateShipAsync(shipId, createShipDto.ShipName ?? string.Empty,
            createShipDto.CreatedDate ?? DateTime.MinValue);
        
        tasks.Add(crateShipTask);
        foreach (var compartmentName in createShipDto.CompartmentNames)
        {
            var createCompartmentTask = CreateCompartmentAsync(compartmentName!, shipId, createShipDto.ShipName!);
            tasks.Add(createCompartmentTask);
        }

        await Task.WhenAll(tasks);
    }

    private async Task CreateShipAsync(string id, string shipName, DateTime createdDate)
    {
        var ship = new Ship
        {
            Id = id,
            BuildTime = createdDate,
            Name = shipName,
            Deleted = false
        };

        await _shipRepository.SaveAsync(ship);
    }

    private async Task CreateCompartmentAsync(string compartmentName, string shipId, string shipName)
    {
        var id = $"{_prefixesConfig.Compartment}_{shipName}_{compartmentName}";
        var compartment = new Compartment
        {
            Id = id,
            Name = compartmentName,
            ShipId = shipId,
            Deleted = false
        };

        await _compartmentRepository.SaveAsync(compartment);
    }
}