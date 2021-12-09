using Flexio.Data.Configurations.ApplicationVersions;
using Flexio.Data.Models.ApplicationVersions;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Data
{
    public class FlexioContext : DbContext
    {
        public FlexioContext() { }

        public FlexioContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
        }
    }
}
