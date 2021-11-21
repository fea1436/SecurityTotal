using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _02_SecTotalQuery.Contract.Branch;
using BranchManagement.Infrastructure.EFCore;

namespace _02_SecTotalQuery.Query
{
    public class BranchQuery : IBranchQuery
    {
        private readonly BranchContext _branchContext;

        public BranchQuery(BranchContext branchContext)
        {
            _branchContext = branchContext;
        }

        public BranchQueryModel GetBranchBy(string slug)
        {
            return _branchContext.Branches.Select(x => new BranchQueryModel
            {
                Title =x.Title,
                Code = x.Code,
                HeadQ = x.HeadQ,
                OldCode = x.OldCode,
                AuthorizationDate = x.AuthorizationDate.ToFarsi(),
                AuthorizationCode = x.AuthorizationCode,
                TelPreCode = x.TelPreCode,
                Telephone = x.Telephone,
                Fax = x.Fax,
                PostalCode = x.PostalCode,
                ActivationStatus = x.ActivationStatus,
                Address = x.Address,
                OwnershipStatus = x.OwnershipStatus,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x=>x.Slug == slug);
        }

        public BranchQueryModel GetBranchBy(int code)
        {
            return _branchContext.Branches.Select(x => new BranchQueryModel
            {
                Title = x.Title,
                Code = x.Code,
                HeadQ = x.HeadQ,
                OldCode = x.OldCode,
                AuthorizationDate = x.AuthorizationDate.ToFarsi(),
                AuthorizationCode = x.AuthorizationCode,
                TelPreCode = x.TelPreCode,
                Telephone = x.Telephone,
                Fax = x.Fax,
                PostalCode = x.PostalCode,
                ActivationStatus = x.ActivationStatus,
                Address = x.Address,
                OwnershipStatus = x.OwnershipStatus,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Code == code);
        }

        public List<BranchQueryModel> GetBranches()
        {
            return _branchContext.Branches.Select(x => new BranchQueryModel
            {
                Title = x.Title,
                Code = x.Code,
                HeadQ = x.HeadQ,
                OldCode = x.OldCode,
                AuthorizationDate = x.AuthorizationDate.ToFarsi(),
                AuthorizationCode = x.AuthorizationCode,
                TelPreCode = x.TelPreCode,
                Telephone = x.Telephone,
                Fax = x.Fax,
                PostalCode = x.PostalCode,
                ActivationStatus = x.ActivationStatus,
                Address = x.Address,
                OwnershipStatus = x.OwnershipStatus,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).ToList();
        }
    }
}
