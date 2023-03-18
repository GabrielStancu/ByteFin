using DataCollectionService.Business.Environment;
using DataCollectionService.Business.Services;
using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;
using DataCollectionService.Data.Settings;
using DataCollectionService.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) => {
        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Settings
        services.AddScoped(typeof(IDatabaseSettings<Humidity>), typeof(HumiditySettings));
        services.AddScoped(typeof(IDatabaseSettings<Temperature>), typeof(TemperatureSettings));
        services.AddScoped(typeof(IDatabaseSettings<Location>), typeof(LocationSettings));

        // Configurations
        services.Configure<DatabaseConfiguration>(
            context.Configuration.GetSection("Database"));
        services.AddSingleton<IDatabaseConfiguration>(provider =>
            provider.GetRequiredService<IOptions<DatabaseConfiguration>>().Value);

        services.Configure<MeasurementPrefixConfiguration>(
            context.Configuration.GetSection("MeasurmentPrefix"));
        services.AddSingleton<IMeasurementPrefixConfiguration>(provider =>
            provider.GetRequiredService<IOptions<MeasurementPrefixConfiguration>>().Value);

        services.Configure<AllowedValuesConfiguration>(
            context.Configuration.GetSection("AllowedValues"));
        services.AddSingleton<IAllowedValuesConfiguration>(provider =>
            provider.GetRequiredService<IOptions<AllowedValuesConfiguration>>().Value);

        // Services
        services.AddScoped<IGeneratorService, GeneratorService>();

        // Generators
        services.AddScoped(typeof(IGenerator<Humidity>), typeof(HumidityGenerator));
        services.AddScoped(typeof(IGenerator<Temperature>), typeof(TemperatureGenerator));
        services.AddScoped(typeof(IGenerator<Location>), typeof(LocationGenerator));
    })
    .Build();

host.Run();
