using DataCollectionService.DTOs.Replies;
using DataCollectionService.DTOs.Requests;

namespace DataCollectionService.Business.Services;

public interface IGeneratorService
{
    public EnvironmentConditions? Generate(EnvironmentParamaters parameters);
}
