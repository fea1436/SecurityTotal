using System.Collections.Generic;
using _00_Framework.Application;

namespace FraudManagement.Application.Contract.FrdCategory
{
    public interface IFraudCategoryApplication
    {
        OperationResult Create(CreateFraudCategory command);
        OperationResult Edit(EditFraudCategory command);
        EditFraudCategory GetDetails(long id);
        List<FraudCategoryViewModel> Search(FraudCategorySearchModel command);
    }
}
