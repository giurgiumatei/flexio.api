using Flexio.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flexio.Data.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Token).IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Token).IsUnique();
        }
    }
}
