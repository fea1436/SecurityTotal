using System.Collections.Generic;
using BranchManagement.Application.Contract.Branch;

namespace PersonnelManagement.Domain.HireTypeAgg
{
    public interface IHireTypeRepository
    {
        EditBranch GetDetails(long id);
        List<BranchViewModel> GetAllHeadQ();
        List<BranchViewModel> Search(BranchSearchModel searchModel);
    }
}
