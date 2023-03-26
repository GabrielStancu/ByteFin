using AutoMapper;
using ShipService.Contracts.GetShipsInfo;
using ShipService.Data;

namespace ShipService.Business.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ship, ShipResponse>();
        CreateMap<Compartment, CompartmentResponse>();
    }
}