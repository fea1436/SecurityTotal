using BranchManagement.Domain.BranchAgg;
using BranchManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BranchManagement.Infrastructure.EFCore
{
    public class BranchContext : DbContext
    {
        private DbSet<Branch> Branches { get; set; }

        public BranchContext(DbContextOptions<BranchContext> options) : base(options)
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
