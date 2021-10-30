﻿using BranchManagement.Application;
using BranchManagement.Application.Contract.Branch;
using BranchManagement.Domain.BranchAgg;
using BranchManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BranchManagement.Configuration
{
    public class BranchManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IBranchApplication, BranchApplication>();
            services.AddTransient<IBranchRepository, IBranchRepository>();

            services.AddDbContext<BranchContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
