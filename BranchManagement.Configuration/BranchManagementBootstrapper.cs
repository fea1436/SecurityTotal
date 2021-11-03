using BranchManagement.Application;
using BranchManagement.Application.Contract.Branch;
using BranchManagement.Application.Contract.OwnershipStatus;
using BranchManagement.Domain.BranchAgg;
using BranchManagement.Domain.OwnershipStatusAgg;
using BranchManagement.Infrastructure.EFCore;
using BranchManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BranchManagement.Configuration
{
    public class BranchManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IBranchApplication, BranchApplication>();
            services.AddTransient<IBranchRepository, BranchRepository>();

            services.AddTransient<IOwnershipStatusApplication, OwnershipStatusApplication>();
            services.AddTransient<IOwnershipStatusRepository, OwnershipStatusRepository>();

            services.AddDbContext<BranchContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
