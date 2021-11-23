using CoreManagement.Domain.PersonnelAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreManagement.Infrastructure.EFCore.Mapping
{
    public class PersonnelMapping : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.ToTable("Personnel");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Ssid).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.HireTypeId).IsRequired();

            builder.HasOne(x => x.HireType)
                .WithMany(x => x.Personnel)
                .HasForeignKey(x => x.HireTypeId);
        }
    }
}
