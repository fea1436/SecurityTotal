﻿using System;
using _01_Framework.Infrastructure;
using BranchManagement.Application.Contract.Branch;
using BranchManagement.Domain.BranchAgg;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;

namespace BranchManagement.Infrastructure.EFCore.Repository
{
    public class BranchRepository : RepositoryBase<long, Branch>, IBranchRepository
    {
        private readonly BranchContext _branchContext;

        public BranchRepository(BranchContext context) : base(context)
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
                AuthorizationDate = x.AuthorizationDate,
                ActivationStatus = x.ActivationStatus,
                TelPreCode = x.TelPreCode,
                Telephone = x.Telephone,
                Fax = x.Fax,
                PostalCode = x.PostalCode,
                Address = x.Address,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<BranchViewModel> Search(BranchSearchModel searchModel)
        {
            var headQ = _branchContext.Branches.Select(x=> new { x.Code, x.Title }).ToList();

            var query = _branchContext.Branches.Select(x => new BranchViewModel
            {
                Code = x.Code,
                Title = x.Title,
                OldCode = x.OldCode,
                AuthorizationCode = x.AuthorizationCode,
                AuthorizationDate = x.AuthorizationDate.ToFarsi(),
                Address = x.Address,
                FullTelNumber = x.TelPreCode + x.Telephone
            });

            if (searchModel.Code > 0)
                query = query.Where(x => x.Code == searchModel.Code);

            if (searchModel.OldCode > 0)
                query = query.Where(x => x.OldCode == searchModel.OldCode);

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (!searchModel.ActivationStatus)
                query = query.Where(x => !x.ActivationStatus);

            var branches = query.OrderByDescending(x=>x.Code).ToList();

            foreach (var branch in branches)
            {
                branch.HeadQ = headQ.FirstOrDefault(x => x.Title.Contains(searchModel.HeadQ))?.Title;
            }

            return query.ToList();
        }
    }
}
