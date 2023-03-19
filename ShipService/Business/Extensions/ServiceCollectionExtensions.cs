using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ShipService.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddConfiguration<T>(this IServiceCollection services, HostBuilderContext context, string sectionName) where T : class
    {
        services.Configure<T>(
            context.Configuration.GetSection(sectionName));
        services.AddSingleton(provider =>
            provider.GetRequiredService<IOptions<T>>().Value);
    }
}