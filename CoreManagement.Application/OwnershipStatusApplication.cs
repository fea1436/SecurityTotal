using System.Collections.Generic;
using CoreManagement.Application.Contract.OwnershipStatus;
using CoreManagement.Domain.OwnershipStatusAgg;

namespace CoreManagement.Application
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
