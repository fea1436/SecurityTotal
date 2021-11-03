using System.Collections.Generic;
using BranchManagement.Application.Contract.OwnershipStatus;
using BranchManagement.Domain.OwnershipStatusAgg;

namespace BranchManagement.Infrastructure.EFCore.Repository
{
    public class OwnershipStatusRepository : IOwnershipStatusRepository
    {
        public List<OwnershipStatusViewModel> GetAllOwnershipStatus()
        {
            var ownershipStatus = new List<OwnershipStatusViewModel>()
            {
                new OwnershipStatusViewModel() {Status = false, Title = "استیجاری"},
                new OwnershipStatusViewModel() {Status = true, Title = "ملکی"},
            };

            return ownershipStatus;
        }
    }
}
