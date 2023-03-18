using DataCollectionService.Business.Environment.Models;

namespace DataCollectionService.Business;

public interface IGeneratorService
{
    public EnvironmentConditions? Generate(EnvironmentParamaters paramaters);
}
