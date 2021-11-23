using System.Collections.Generic;
using _01_Framework.Domain;
using CoreManagement.Application.Contract.Personnel;

namespace CoreManagement.Domain.PersonnelAgg
{
    public interface IPersonnelRepository : IRepository<long , Personnel>
    {
        EditPersonnel GetDetails(long id);
        List<PersonnelViewModel> GetAllPersonnel();
        List<PersonnelViewModel> Search(PersonnelSearchModel searchModel);
    }
}
