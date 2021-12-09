using Flexio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace Flexio.Migrations
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<FlexioContext>
    {
        private const string LocalSql = "server=(LocalDB)\\MSSQLLocalDB;database=Flexio-Local;Trusted_Connection=True;";

        private static readonly string MigrationAssemblyName = typeof(DesignTimeContextFactory).Assembly.GetName().Name;

        public FlexioContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FlexioContext>()
                .UseSqlServer(args.FirstOrDefault() ?? LocalSql,
                op => op.MigrationsAssembly(MigrationAssemblyName));
            return new FlexioContext(builder.Options);
        }
    }
}
