using BranchManagement.Domain.BranchAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BranchManagement.Infrastructure.EFCore.Mapping
{
    public class BranchMapping : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HeadQ).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.OldCode).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AuthorizationCode).HasMaxLength(50).IsRequired();
            builder.Property(x => x.AuthorizationDate).IsRequired();
            builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.TelPreCode).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Telephone).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Fax).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();
        }
    }
}
