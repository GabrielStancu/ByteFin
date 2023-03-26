using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShipService.Business.ShipCompartmentsCreation;
using ShipService.Business.ShipDataCollection;
using ShipService.Configuration;
using ShipService.Data;
using ShipService.Persistence;
using ShipService.Persistence.Settings;

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
        services.Configure<DatabaseConfiguration>(context.Configuration.GetSection(DatabaseConfiguration.SectionName));
        services.Configure<PrefixesConfiguration>(context.Configuration.GetSection(PrefixesConfiguration.SectionName));
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
