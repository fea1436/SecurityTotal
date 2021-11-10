using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonnelManagement.Application;
using PersonnelManagement.ApplicationContract.HireType;
using PersonnelManagement.ApplicationContract.Personnel;
using PersonnelManagement.Domain.HireTypeAgg;
using PersonnelManagement.Domain.PersonnelAgg;
using PersonnelManagement.Infrastructure.EFCore;
using PersonnelManagement.Infrastructure.EFCore.Repository;

namespace PersonnelManagement.Configuration
{
    public class PersonnelManagementBootstrapper 
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IHireTypeApplication, HireTypeApplication>();
            services.AddTransient<IHireTypeRepository, HireTypeRepository>();

            services.AddTransient<IPersonnelApplication, PersonnelApplication>();
            services.AddTransient<IPersonnelRepository, PersonnelRepository>();

            services.AddDbContext<PersonnelContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
