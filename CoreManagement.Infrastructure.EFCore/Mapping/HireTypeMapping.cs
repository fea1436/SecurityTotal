using CoreManagement.Domain.HireTypeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreManagement.Infrastructure.EFCore.Mapping
{
    public class HireTypeMapping : IEntityTypeConfiguration<HireType>
    {
        public void Configure(EntityTypeBuilder<HireType> builder)
        {
            builder.ToTable("HireTypes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(150);

            builder.HasMany(x => x.Personnel)
                .WithOne(x => x.HireType)
                .HasForeignKey(x => x.HireTypeId);
        }
    }
}
