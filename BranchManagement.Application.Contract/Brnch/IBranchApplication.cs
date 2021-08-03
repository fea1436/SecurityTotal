using System.Collections.Generic;
using _00_Framework.Application;

namespace BranchManagement.Application.Contract.Brnch
{
    public interface IBranchApplication
    {
        OperationResult Create(CreateBranch command);
        OperationResult Edit(EditBranch command);
        EditBranch GetDetails(long id);
        List<BranchViewModel> Search(BranchSearchModel command);
    }
}
