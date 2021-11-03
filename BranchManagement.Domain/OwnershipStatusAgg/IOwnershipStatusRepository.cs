using System.Collections.Generic;
using BranchManagement.Application.Contract.OwnershipStatus;

namespace BranchManagement.Domain.OwnershipStatusAgg
{
    public interface IOwnershipStatusRepository
    {
        List<OwnershipStatusViewModel> GetAllOwnershipStatus();
    }
}
