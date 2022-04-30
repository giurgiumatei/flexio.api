using Flexio.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flexio.Data.Configurations.Users
{
    public class GenderLookupConfiguration : IEntityTypeConfiguration<GenderLookup>
    {
        public void Configure(EntityTypeBuilder<GenderLookup> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever().HasConversion<int>();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new GenderLookup { Id = Gender.Male, Name = Gender.Male.ToString() },
                new GenderLookup { Id = Gender.Female, Name = Gender.Female.ToString() },
                new GenderLookup { Id = Gender.Other, Name = Gender.Other.ToString() }
            );
        }
    }
}