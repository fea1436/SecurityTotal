using System.Collections.Generic;
using _00_Framework.Domain;
using BranchManagement.Application.Contract.Brnch;

namespace BranchManagement.Domain.BranchAgg
{
    public interface IBranchRepository : IRepository<long, Branch>
    {
        EditBranch GetDetails(long id);
        List<BranchViewModel> Search(BranchSearchModel command);
    }
}
