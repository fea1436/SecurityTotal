using System.Collections.Generic;
using CoreManagement.Application.Contract.OwnershipStatus;
using CoreManagement.Domain.OwnershipStatusAgg;

namespace CoreManagement.Infrastructure.EFCore.Repository
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
