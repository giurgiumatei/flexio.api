using Flexio.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flexio.Data.Configurations.Users
{
    public class RoleLookupConfiguration : IEntityTypeConfiguration<RoleLookup>
    {
        public void Configure(EntityTypeBuilder<RoleLookup> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever().HasConversion<int>();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new RoleLookup {Id = Role.FlexioAdmin, Name = Role.FlexioAdmin.ToString()},
                new RoleLookup {Id = Role.Client, Name = Role.Client.ToString()},
                new RoleLookup {Id = Role.IdentityChecker, Name = Role.IdentityChecker.ToString()}
            );
        }
    }
}