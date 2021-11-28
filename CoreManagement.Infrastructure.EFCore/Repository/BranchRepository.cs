using _01_Framework.Infrastructure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01_Framework.Application;
using CoreManagement.Application.Contract.Branch;
using CoreManagement.Domain.BranchAgg;

namespace CoreManagement.Infrastructure.EFCore.Repository
{
    public class BranchRepository : RepositoryBase<long, Branch>, IBranchRepository
    {
        private readonly CoreContext _branchContext;

        public BranchRepository(CoreContext context) : base(context)
        {
            _branchContext = context;
        }

        public EditBranch GetDetails(long id)
        {
            return _branchContext.Branches.Select(x => new EditBranch
            {
                Id = x.Id,
                HeadQ = x.HeadQ,
                Code = x.Code,
                Title = x.Title,
                OldCode = x.OldCode,
                AuthorizationCode = x.AuthorizationCode,
                AuthorizationDate = x.AuthorizationDate.ToString(CultureInfo.InvariantCulture),
                ActivationStatus = x.ActivationStatus,
                TelPreCode = x.TelPreCode,
                Telephone = x.Telephone,
                Fax = x.Fax,
                PostalCode = x.PostalCode,
                Address = x.Address,
                OwnershipStatus = x.OwnershipStatus,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<BranchViewModel> GetAllHeadQ()
        {
            return _branchContext.Branches.Where(x => x.HeadQ == 1234568).Select(x => new BranchViewModel
            {
                Code = x.Code,
                Title = x.Title
            }).OrderBy(x => x.Title).ToList();
        }

        public List<BranchViewModel> GetAllBranches()
        {
            return _branchContext.Branches.Select(x => new BranchViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Title = x.Title,
                OldCode = x.OldCode,
                AuthorizationCode = x.AuthorizationCode,
                AuthorizationDate = x.AuthorizationDate.ToFarsi(),
                Address = x.Address,
                ActivationStatus = x.ActivationStatus,
                OwnershipStatusCode = x.OwnershipStatus,
                FullTelNumber = x.TelPreCode + x.Telephone
            }).ToList();
        }

        public List<BranchViewModel> Search(BranchSearchModel searchModel)
        {
            var headQ = _branchContext.Branches.Select(x => new { x.Code, x.Title }).ToList();

            var query = _branchContext.Branches.Select(x => new BranchViewModel
            {
                Id = x.Id,
                Code = x.Code,
                HeadQCode = x.HeadQ,
                Title = x.Title,
                OldCode = x.OldCode,
                AuthorizationCode = x.AuthorizationCode,
                AuthorizationDate = x.AuthorizationDate.ToFarsi(),
                Address = x.Address,
                ActivationStatus = x.ActivationStatus,
                OwnershipStatusCode = x.OwnershipStatus,
                FullTelNumber = x.TelPreCode + x.Telephone
            });

            if (searchModel.HeadQ != 0)
                query = query.Where(x => x.HeadQCode == searchModel.HeadQ);

            if (searchModel.Code != 0)
                query = query.Where(x => x.Code == searchModel.Code);

            

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.ActivationStatus)
                query = query.Where(x => !x.ActivationStatus);
            else
                query = query.Where(x => x.ActivationStatus);


            var branches = query.OrderBy(x => x.Title).ToList();

            foreach (var branch in branches)
            {
                branch.HeadQTitle = headQ.FirstOrDefault(x => x.Code == branch.HeadQCode)?.Title;

                if (branch.OwnershipStatusCode)
                {
                    branch.OwnershipStatusTitle = "ملکی";
                }
                else
                {
                    branch.OwnershipStatusTitle = "استیجاری";
                }
            }

            return branches;
        }
    }
}
