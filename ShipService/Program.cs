using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShipService.Business.Extensions;
using ShipService.Business.Services;
using ShipService.Data.Models;
using ShipService.Data.Repositories;
using ShipService.Environment.Configuration;
using ShipService.Environment.Settings;

var host = new HostBuilder()
    .ConfigureServices((context, services) =>
    {
        // Repositories
        services.AddScoped(typeof(IGenericRepository<Ship>), typeof(GenericRepository<Ship>));
        services.AddScoped<ICompartmentRepository, CompartmentRepository>();

        // Services
        services.AddScoped<IShipCompartmentsCollector, ShipCompartmentsCollector>();
        services.AddScoped<IShipCreator, ShipCreator>();

        // Settings
        services.AddScoped(typeof(IDatabaseSettings<Ship>), typeof(ShipSettings));
        services.AddScoped(typeof(IDatabaseSettings<Compartment>), typeof(CompartmentSettings));

        // Configurations
        services.AddConfiguration<DatabaseConfiguration>(context, "Database");
        services.AddConfiguration<PrefixesConfiguration>(context, "Prefixes");
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
