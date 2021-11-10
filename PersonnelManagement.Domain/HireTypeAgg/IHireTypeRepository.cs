using System.Collections.Generic;
using _01_Framework.Domain;
using PersonnelManagement.ApplicationContract.HireType;

namespace PersonnelManagement.Domain.HireTypeAgg
{
    public interface IHireTypeRepository : IRepository<long, HireType>
    {
        EditHireType GetDetails(long id);
        List<HireTypeViewModel> GetAllHireTypes();
        List<HireTypeViewModel> Search(HireTypeSearchModel searchModel);
    }
}
