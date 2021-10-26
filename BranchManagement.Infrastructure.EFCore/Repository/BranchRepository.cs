using _01_Framework.Infrastructure;
using BranchManagement.Application.Contract.Branch;
using BranchManagement.Domain.BranchAgg;
using System.Collections.Generic;

namespace BranchManagement.Infrastructure.EFCore.Repository
{
    public class BranchRepository : RepositoryBase<long, Branch>, IBranchRepository
    {
        private readonly BranchContext _context;

        public BranchRepository(BranchContext context) : base(context)
        {
            _context = context;
        }

        public List<BranchViewModel> Search(BranchSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
