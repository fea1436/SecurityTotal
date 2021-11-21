using System.Collections.Generic;

namespace _02_SecTotalQuery.Contract.Branch
{
    public interface IBranchQuery
    {
        BranchQueryModel GetBranchBy(string slug);
        BranchQueryModel GetBranchBy(int code);
        List<BranchQueryModel> GetBranches();
    }
}
