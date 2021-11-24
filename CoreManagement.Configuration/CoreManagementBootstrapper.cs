using _02_SecTotalQuery.Contract.Branch;
using _02_SecTotalQuery.Query;
using CoreManagement.Application;
using CoreManagement.Application.Contract.Branch;
using CoreManagement.Application.Contract.HireType;
using CoreManagement.Application.Contract.OwnershipStatus;
using CoreManagement.Application.Contract.Personnel;
using CoreManagement.Domain.BranchAgg;
using CoreManagement.Domain.HireTypeAgg;
using CoreManagement.Domain.OwnershipStatusAgg;
using CoreManagement.Domain.PersonnelAgg;
using CoreManagement.Infrastructure.EFCore;
using CoreManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreManagement.Configuration
{
    public class CoreManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IBranchApplication, BranchApplication>();
            services.AddTransient<IBranchRepository, BranchRepository>();

            services.AddTransient<IOwnershipStatusApplication, OwnershipStatusApplication>();
            services.AddTransient<IOwnershipStatusRepository, OwnershipStatusRepository>();

            services.AddTransient<IHireTypeApplication, HireTypeApplication>();
            services.AddTransient<IHireTypeRepository, HireTypeRepository>();

            services.AddTransient<IPersonnelApplication, PersonnelApplication>();
            services.AddTransient<IPersonnelRepository, PersonnelRepository>();

            services.AddTransient<IBranchQuery, BranchQuery>();


            services.AddDbContext<CoreContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
