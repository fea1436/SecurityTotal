using System.Collections.Generic;
using _01_Framework.Application;

namespace PersonnelManagement.ApplicationContract.Personnel
{
    public interface IPersonnelApplication
    {
        OperationResult Add(CreatePersonnel command);
        OperationResult Edit(EditPersonnel command);
        EditPersonnel GetDetails(long id);
        List<PersonnelViewModel> GetAllPersonnel();
        List<PersonnelViewModel> Search(PersonnelSearchModel searchModel);
    }
}
