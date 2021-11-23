using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using CoreManagement.Application.Contract.HireType;
using CoreManagement.Domain.HireTypeAgg;

namespace CoreManagement.Infrastructure.EFCore.Repository
{
    public class HireTypeRepository : RepositoryBase<long, HireType>, IHireTypeRepository
    {
        private readonly CoreContext _coreContext;

        public HireTypeRepository(CoreContext context) : base(context)
        {
            _coreContext = context;
        }

        public EditHireType GetDetails(long id)
        {
            return _coreContext.HireTypes.Select(x => new EditHireType
            {
                Id = x.Id,
                Title = x.Title,
                IsActive = x.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<HireTypeViewModel> GetAllHireTypes()
        {
            return _coreContext.HireTypes.Select(x => new HireTypeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToFarsi(),
                IsActive = x.IsActive
            }).OrderBy(x=>x.Title).ToList();
        }


        public List<HireTypeViewModel> Search(HireTypeSearchModel searchModel)
        {
            var query = _coreContext.HireTypes.Select(x => new HireTypeViewModel
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
