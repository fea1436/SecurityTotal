using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _00_Framework.Infrastructure;
using BranchManagement.Application.Contract.Brnch;
using BranchManagement.Domain.BranchAgg;

namespace BranchManagement.Infrastructure.EFCore.Repository
{
    public class BranchRepository : RepositoryBase<long, Branch>, IBranchRepository
    {
        private readonly BranchContext _context;

        public BranchRepository(BranchContext context) : base(context)
        {
            _context = context;
        }

        public EditBranch GetDetails(long id)
        {
            return _context.Branches.Select(x => new EditBranch
            {
                Id = x.Id,
                Name = x.Name,
                HeadQ = x.HeadQ,
                Code = x.Code,
                OldCode = x.OldCode,
                AuthorizationCode = x.AuthorizationCode,
                AuthorizationDate = x.AuthorizationDate,
                TelPreCode = x.TelPreCode,
                TelNumber = x.TelNumber,
                FaxNumber = x.FaxNumber,
                IsActive = x.IsActive,
                Address = x.Address,
                LastChange = x.LastChange,
                IsHeadQ = x.IsHeadQ,
                Slug = x.Slug,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<BranchViewModel> Search(BranchSearchModel command)
        {
            var query = _context.Branches.Select(x => new BranchViewModel
            {
                Code = x.Code,
                HeadQ = x.HeadQ,
                Name = x.Name,
                OldCode = x.OldCode,
                IsActive = x.IsActive,
                LastChange = x.LastChange.ToString(CultureInfo.InvariantCulture)
            });

            if (!String.IsNullOrWhiteSpace(command.Name))
                query = query.Where(x => x.Name.Contains(command.Name));

            if (command.HeadQ != 0)
                query = query.Where(x => x.HeadQ == command.HeadQ);

            if (command.Id != 0)
                query = query.Where(x => x.Id == command.Id);

            if (command.Code != 0)
                query = query.Where(x => x.Code == command.Code);

            if (command.OldCode != 0)
                query = query.Where(x => x.OldCode == command.OldCode);

            return query.OrderByDescending(x => x.Code).ToList();
        }
    }
}
