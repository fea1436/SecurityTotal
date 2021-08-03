using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using _00_Framework.Application;
using BranchManagement.Application.Contract.Brnch;
using BranchManagement.Domain.BranchAgg;

namespace BranchManagement.Application
{
    public class BranchApplication : IBranchApplication
    {
        private readonly IBranchRepository _branchRepository;

        public BranchApplication(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public OperationResult Create(CreateBranch command)
        {
            var operation = new OperationResult();

            if (_branchRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.Duplicated);

            string slug = command.Slug.Slugify();

            var branch = new Branch(command.Name, command.HeadQ, command.Code, command.OldCode,
                command.AuthorizationCode, command.AuthorizationDate,
                command.TelPreCode, command.TelNumber, command.FaxNumber, command.Address, command.IsHeadQ,
                command.Slug, command.Keywords, command.MetaDescription);

            _branchRepository.Create(branch);
            _branchRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditBranch command)
        {
            var operation = new OperationResult();

            var branch = _branchRepository.Get(command.Id);

            if (branch == null)
                return operation.Failed(ApplicationMessages.NotFound);

            if (_branchRepository.Exists(x => x.Name == command.Name && x.Code != command.Code))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            string slug = command.Slug.Slugify();
            branch.Edit(command.Name, command.HeadQ, command.Code, command.OldCode, command.AuthorizationCode, command.AuthorizationDate,
                command.TelPreCode,command.TelNumber, command.FaxNumber, command.IsActive, command.Address, command.IsHeadQ,
                command.Slug, command.Keywords, command.MetaDescription);

            _branchRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditBranch GetDetails(long id)
        {
            return _branchRepository.GetDetails(id);
        }

        public List<BranchViewModel> Search(BranchSearchModel command)
        {
            return _branchRepository.Search(command);
        }
    }
}
