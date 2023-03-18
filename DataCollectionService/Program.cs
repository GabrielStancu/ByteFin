using DataCollectionService.Business.Environment;
using DataCollectionService.Business.Services;
using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;
using DataCollectionService.Data.Settings;
using DataCollectionService.Extensions;
using DataCollectionService.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) => 
    {
        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Settings
        services.AddScoped(typeof(IDatabaseSettings<Humidity>), typeof(HumiditySettings));
        services.AddScoped(typeof(IDatabaseSettings<Temperature>), typeof(TemperatureSettings));
        services.AddScoped(typeof(IDatabaseSettings<Location>), typeof(LocationSettings));

        // Configurations
        services.AddConfiguration<DatabaseConfiguration>(context, "Database");
        services.AddConfiguration<MeasurementPrefixConfiguration>(context, "MeasurementPrefix");
        services.AddConfiguration<AllowedValuesConfiguration>(context, "AllowedValues");

        // Services
        services.AddScoped<IGeneratorService, GeneratorService>();

        // Generators
        services.AddScoped(typeof(IGenerator<Humidity>), typeof(HumidityGenerator));
        services.AddScoped(typeof(IGenerator<Temperature>), typeof(TemperatureGenerator));
        services.AddScoped(typeof(IGenerator<Location>), typeof(LocationGenerator));
    })
    .Build();

host.Run();
