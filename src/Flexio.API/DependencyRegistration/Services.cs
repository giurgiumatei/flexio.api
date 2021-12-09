using Flexio.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Flexio.API.DependencyRegistration
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<FlexioContext, FlexioContext>();
        }
    }
}
