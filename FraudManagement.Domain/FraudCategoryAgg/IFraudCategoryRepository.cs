using System.Collections.Generic;
using _00_Framework.Domain;
using FraudManagement.Application.Contract.FrdCategory;

namespace FraudManagement.Domain.FraudCategoryAgg
{
    public interface IFraudCategoryRepository : IRepository<long, FraudCategory>
    {
        EditFraudCategory GetDeatails(long id);
        List<FraudCategoryViewModel> Search(FraudCategorySearchModel searchModel);
    }
}
