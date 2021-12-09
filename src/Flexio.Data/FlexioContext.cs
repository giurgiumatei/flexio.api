using Flexio.Data.Configurations.ApplicationVersions;
using Flexio.Data.Configurations.Users;
using Flexio.Data.Models.ApplicationVersions;
using Flexio.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Flexio.Data
{
    public class FlexioContext : DbContext
    {
        public FlexioContext() { }

        public FlexioContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
