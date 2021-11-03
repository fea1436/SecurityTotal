using System.Collections.Generic;
using BranchManagement.Application.Contract.OwnershipStatus;
using BranchManagement.Domain.OwnershipStatusAgg;

namespace BranchManagement.Application
{
    public class OwnershipStatusApplication : IOwnershipStatusApplication
    {
        private readonly IOwnershipStatusRepository _ownershipStatusRepository;

        public OwnershipStatusApplication(IOwnershipStatusRepository ownershipStatusRepository)
        {
            _ownershipStatusRepository = ownershipStatusRepository;
        }

        public List<OwnershipStatusViewModel> GetAllOwnershipStatus()
        {
            return _ownershipStatusRepository.GetAllOwnershipStatus();
        }
    }
}
