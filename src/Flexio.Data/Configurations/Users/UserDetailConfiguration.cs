using Flexio.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flexio.Data.Configurations.Users
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DateOfBirth).IsRequired();

            builder.HasAlternateKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithOne(x => x.UserDetail)
                .HasForeignKey<UserDetail>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Creator)
                .WithOne(x => x.CreatorDetail)
                .HasForeignKey<UserDetail>(x => x.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ActualOwner)
                .WithOne(x => x.ActualOwnerDetail)
                .HasForeignKey<UserDetail>(x => x.ActualOwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
