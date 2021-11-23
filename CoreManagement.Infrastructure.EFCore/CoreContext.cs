using CoreManagement.Domain.BranchAgg;
using CoreManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CoreManagement.Infrastructure.EFCore
{
    public class CoreContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(BranchMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
