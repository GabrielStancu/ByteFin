using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShipService.Business.CreateShipWithCompartments;
using ShipService.Business.Extensions;
using ShipService.Business.GetShipsInfo;
using ShipService.Business.RequireShipConditions;
using ShipService.Configuration;
using ShipService.Data;
using ShipService.Persistence;
using ShipService.Persistence.Settings;

var host = new HostBuilder()
    .ConfigureServices((context, services) =>
    {
        // Repositories
        services.AddScoped<IShipRepository, ShipRepository>();
        services.AddScoped<ICompartmentRepository, CompartmentRepository>();

        // Services
        services.AddScoped<IShipCompartmentsCollector, ShipCompartmentsCollector>();
        services.AddScoped<IShipCreator, ShipCreator>();
        services.AddScoped<IShipInfoService, ShipsInfoService>();

        // Settings
        services.AddScoped(typeof(IDatabaseSettings<Ship>), typeof(ShipSettings));
        services.AddScoped(typeof(IDatabaseSettings<Compartment>), typeof(CompartmentSettings));

        // Configurations
        services.AddConfiguration<DatabaseConfiguration>(context, DatabaseConfiguration.SectionName);
        services.AddConfiguration<PrefixesConfiguration>(context, PrefixesConfiguration.SectionName);

        // AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
