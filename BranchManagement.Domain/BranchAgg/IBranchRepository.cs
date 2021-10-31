﻿using System.Collections.Generic;
using _01_Framework.Domain;
using BranchManagement.Application.Contract.Branch;

namespace BranchManagement.Domain.BranchAgg
{
    public interface IBranchRepository : IRepository<long, Branch>
    {
        EditBranch GetDetails(long id);
        List<BranchViewModel> GetAllHeadQ();
        List<BranchViewModel> Search(BranchSearchModel searchModel);
    }
}
