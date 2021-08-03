using System;
using BranchManagement.Application;
using BranchManagement.Application.Contract.Brnch;
using BranchManagement.Domain.BranchAgg;
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

            services.AddDbContext<BranchContext>(x => x.UseSqlServer(connectionString));
        }
    }
}