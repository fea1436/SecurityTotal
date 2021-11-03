using System.Collections.Generic;

namespace BranchManagement.Application.Contract.OwnershipStatus
{
    public interface IOwnershipStatusApplication
    {
        List<OwnershipStatusViewModel> GetAllOwnershipStatus();
    }
}
