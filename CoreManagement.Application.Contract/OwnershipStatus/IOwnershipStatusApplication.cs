using System.Collections.Generic;

namespace CoreManagement.Application.Contract.OwnershipStatus
{
    public interface IOwnershipStatusApplication
    {
        List<OwnershipStatusViewModel> GetAllOwnershipStatus();
    }
}
