using Flexio.Data;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.Business.IntegrationTests.Api
{
    public class BaseApiTest : IDisposable
    {
        protected ApiWebApplicationFactory _factory;
        protected HttpClient _client;
        protected IServiceCollection _services;


        private readonly string ConnectionString = "server=(LocalDB)\\MSSQLLocalDB;database=Flexio-Test;Trusted_Connection=True;Integrated Security=True";

        public BaseApiTest()
        {
            _factory = new ApiWebApplicationFactory();
            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {

                    AddDatabaseContext(services);

                    Log.Logger = new LoggerConfiguration()
                      .WriteTo.Console().CreateLogger();

                    
                });
            }).CreateClient();
        }



        public void Dispose()
        {
            _factory.Dispose();
        }

        protected async Task<T> GetHttpResponseResult<T>(HttpResponseMessage message)
        {
            var responseBody = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(responseBody);

            return response;
        }

        private void AddDatabaseContext(IServiceCollection services)
        {
            var descriptor = services
                      .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<FlexioContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            var serviceProvider = new ServiceCollection()
                 .AddEntityFrameworkSqlServer()
                 .BuildServiceProvider();

            services.AddDbContext<FlexioContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
        }

        protected FlexioContext GetContext()
        {
            var contextOptions = new DbContextOptionsBuilder<FlexioContext>()
                .UseSqlServer(ConnectionString)
                .Options;
            return new FlexioContext(contextOptions);
        }
    }
}
