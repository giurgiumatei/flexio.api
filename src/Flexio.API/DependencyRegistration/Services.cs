using Flexio.Azure.Graph.Services;
using Flexio.Azure.Storage.Services;
using Flexio.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Flexio.API.DependencyRegistration;

public static class Services
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IGraphUserManager, GraphUserManager>();
        services.AddScoped<FlexioContext, FlexioContext>();
        services.AddScoped<IBlobStorageService, BlobStorageService>();
    }
}