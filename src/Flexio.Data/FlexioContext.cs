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
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        //Lookups
        public virtual DbSet<RoleLookup> RoleLookup { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationVersionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserDetailConfiguration());
            builder.ApplyConfiguration(new RoleLookupConfiguration());
        }
    }
}
