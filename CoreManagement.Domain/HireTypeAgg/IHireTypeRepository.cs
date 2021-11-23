using System.Collections.Generic;
using _01_Framework.Domain;
using CoreManagement.Application.Contract.HireType;

namespace CoreManagement.Domain.HireTypeAgg
{
    public interface IHireTypeRepository : IRepository<long, HireType>
    {
        EditHireType GetDetails(long id);
        List<HireTypeViewModel> GetAllHireTypes();
        List<HireTypeViewModel> Search(HireTypeSearchModel searchModel);
    }
}
