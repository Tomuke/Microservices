using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.Platform.Api.Infrastructure.Configurations
{
    public class PlatformConfiguration : IEntityTypeConfiguration<Domain.Platform>
    {
        public void Configure(EntityTypeBuilder<Domain.Platform> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .IsRequired();

            builder.Property(x => x.Publisher)
                .IsRequired();

            builder.Property(x => x.Cost)
                .IsRequired();
        }
    }
}
