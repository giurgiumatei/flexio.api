using Flexio.Data;
using Flexio.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.DatabaseContext.IntegrationTests
{
    public class TestContextFactory
    {
        internal FlexioContext _context;
        private static readonly string MigrationAssemblyName = typeof(DesignTimeContextFactory).Assembly.GetName().Name;


        public void CreateDatabase()
        {
            var connectionString = GetConnectionString();
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<FlexioContext>();

            builder.UseSqlServer(connectionString,
                op => op.MigrationsAssembly(MigrationAssemblyName))
                    .UseInternalServiceProvider(serviceProvider);

            _context = new FlexioContext(builder.Options);
            _context.Database.Migrate();
        }

        public void DeleteDatabase()
        {
            _context.Database.EnsureDeleted();
        }

        public string GetConnectionString()
        {
            return $"server=(LocalDB)\\MSSQLLocalDB;database=Flexio-Test {Guid.NewGuid()};integrated security = sspi;";
        }
    }
}
