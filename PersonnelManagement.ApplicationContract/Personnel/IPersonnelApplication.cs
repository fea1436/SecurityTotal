using System.Collections.Generic;

namespace PersonnelManagement.ApplicationContract.Personnel
{
    public interface IPersonnelApplication
    {
        EditPersonnel GetDetails(long id);
        List<PersonnelViewModel> GetAllPersonnel();
        List<PersonnelViewModel> Search(PersonnelSearchModel searchModel);
    }
}
