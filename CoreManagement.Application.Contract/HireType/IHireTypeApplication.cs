using System.Collections.Generic;
using _01_Framework.Application;

namespace CoreManagement.Application.Contract.HireType
{
    public interface IHireTypeApplication
    {
        OperationResult Create(CreateHireType command);
        OperationResult Edit(EditHireType command);
        OperationResult Activate(long id);
        OperationResult Deactivate(long id);
        EditHireType GetDetails(long id);
        List<HireTypeViewModel> GetAll();
        List<HireTypeViewModel> Search(HireTypeSearchModel searchModel);
    }
}
