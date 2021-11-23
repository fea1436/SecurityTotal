using System.Collections.Generic;
using _01_Framework.Application;

namespace CoreManagement.Application.Contract.Branch
{
    public interface IBranchApplication
    {
        OperationResult Add(CreateBranch command);
        OperationResult Edit(EditBranch command);
        OperationResult Activate(long id);
        OperationResult Deactivate(long id);
        EditBranch GetDetails(long id);
        List<BranchViewModel> GetAllHeadQ();
        List<BranchViewModel> Search(BranchSearchModel searchModel);
    }
}
