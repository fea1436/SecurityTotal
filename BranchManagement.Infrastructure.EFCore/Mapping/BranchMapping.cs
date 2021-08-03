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

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.HeadQ).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.OldCode).IsRequired();
            builder.Property(x => x.AuthorizationCode).IsRequired();
            builder.Property(x => x.AuthorizationDate).IsRequired();
            builder.Property(x => x.TelPreCode).HasMaxLength(3).IsRequired();
            builder.Property(x => x.TelNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.FaxNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.LastChange).IsRequired();
            builder.Property(x => x.IsHeadQ).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(150).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(1000).IsRequired();
        }
    }
}
