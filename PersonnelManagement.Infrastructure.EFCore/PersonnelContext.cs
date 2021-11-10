using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.HireTypeAgg;
using PersonnelManagement.Domain.PersonnelAgg;
using PersonnelManagement.Infrastructure.EFCore.Mapping;

namespace PersonnelManagement.Infrastructure.EFCore
{
    public class PersonnelContext : DbContext
    {
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<HireType> HireTypes { get; set; }

        public PersonnelContext(DbContextOptions<PersonnelContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PersonnelMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
