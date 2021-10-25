using System.Collections.Generic;
using _01_Framework.Domain;
using BranchManagement.Application.Contract.Branch;

namespace BranchManagement.Domain.BranchAgg
{
    public interface IBranchRepository : IRepository<long, Branch>
    {
        List<BranchViewModel> Search(BranchSearchModel searchModel);
    }
}
