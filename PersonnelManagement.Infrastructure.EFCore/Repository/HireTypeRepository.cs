using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using PersonnelManagement.ApplicationContract.HireType;
using PersonnelManagement.Domain.HireTypeAgg;

namespace PersonnelManagement.Infrastructure.EFCore.Repository
{
    public class HireTypeRepository : RepositoryBase<long, HireType>, IHireTypeRepository
    {
        private readonly PersonnelContext _personnelContext;

        public HireTypeRepository(PersonnelContext context) : base(context)
        {
            _personnelContext = context;
        }

        public EditHireType GetDetails(long id)
        {
            return _personnelContext.HireTypes.Select(x => new EditHireType
            {
                Id = x.Id,
                Title = x.Title,
                IsActive = x.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<HireTypeViewModel> GetAllHireTypes()
        {
            return _personnelContext.HireTypes.Select(x => new HireTypeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToFarsi(),
                IsActive = x.IsActive
            }).OrderBy(x=>x.Title).ToList();
        }


        public List<HireTypeViewModel> Search(HireTypeSearchModel searchModel)
        {
            var query = _personnelContext.HireTypes.Select(x => new HireTypeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToFarsi(),
                IsActive = x.IsActive
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            return query.OrderBy(x=>x.Title).ToList();
        }
    }
}
