using System.Collections.Generic;
using _01_Framework.Domain;
using CoreManagement.Application.Contract.Branch;

namespace CoreManagement.Domain.BranchAgg
{
    public interface IBranchRepository : IRepository<long, Branch>
    {
        EditBranch GetDetails(long id);
        List<BranchViewModel> GetAllHeadQ();
        List<BranchViewModel> Search(BranchSearchModel searchModel);
    }
}
