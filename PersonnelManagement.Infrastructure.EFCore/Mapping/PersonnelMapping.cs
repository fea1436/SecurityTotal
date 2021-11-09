using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.Domain.PersonnelAgg;

namespace PersonnelManagement.Infrastructure.EFCore.Mapping
{
    public class PersonnelMapping : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.ToTable("Personnel");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Name)
        }
    }
}
