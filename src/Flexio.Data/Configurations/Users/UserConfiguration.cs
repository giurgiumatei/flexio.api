using Flexio.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flexio.Data.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.DateAdded).IsRequired();

        builder.HasIndex(x => x.Email).IsUnique();

        builder.HasMany(x => x.CommentsAddedByUser)
            .WithOne(x => x.AddedByUser)
            .HasForeignKey(x => x.AddedByUserId)
            .OnDelete(DeleteBehavior.ClientCascade);


        builder.HasMany(x => x.CommentsAddedToUser)
            .WithOne(x => x.AddedToUser)
            .HasForeignKey(x => x.AddedToUserId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}