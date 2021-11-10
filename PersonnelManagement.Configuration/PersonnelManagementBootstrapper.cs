using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonnelManagement.Application;
using PersonnelManagement.ApplicationContract.HireType;
using PersonnelManagement.Domain.HireTypeAgg;
using PersonnelManagement.Infrastructure.EFCore.Repository;

namespace PersonnelManagement.Configuration
{
    public class PersonnelManagementBootstrapper 
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IHireTypeApplication, HireTypeApplication>();
            services.AddTransient<IHireTypeRepository, HireTypeRepository>();

            //services.AddTransient<IPersonnelApplication, PersonnelApplication>();
            //services.AddTransient<IPersonnelRepository, PersonnelRepository>();

            //services.AddDbContext<BranchContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
