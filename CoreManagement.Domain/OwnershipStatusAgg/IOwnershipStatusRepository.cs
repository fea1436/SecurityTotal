using System.Collections.Generic;
using CoreManagement.Application.Contract.OwnershipStatus;

namespace CoreManagement.Domain.OwnershipStatusAgg
{
    public interface IOwnershipStatusRepository
    {
        List<OwnershipStatusViewModel> GetAllOwnershipStatus();
    }
}
