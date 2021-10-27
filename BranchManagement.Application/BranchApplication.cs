using System.Collections.Generic;
using _01_Framework.Application;
using BranchManagement.Application.Contract.Branch;
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

        public OperationResult Add(CreateBranch command)
        {
            var operation = new OperationResult();
            if (_branchRepository.Exists(x => x.Title == command.Title) ||
                _branchRepository.Exists(x => x.Code == command.Code) ||
                _branchRepository.Exists(x => x.PostalCode == command.PostalCode))
                return operation.Failed(ApplicationMessages.Duplicated);

            var branch = new Branch(command.Title, command.HeadQ, command.Code, command.OldCode,
                command.AuthorizationCode, command.AuthorizationDate, command.TelPreCode, command.Telephone,
                command.Fax,
                command.PostalCode, command.Address, command.Keywords, command.MetaDescription, command.Slug);

            _branchRepository.Create(branch);
            _branchRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditBranch command)
        {
            var operation = new OperationResult();
            var branch = _branchRepository.Get(command.Id);

            if (branch == null)
                return operation.Failed(ApplicationMessages.NotFound);

            if (_branchRepository.Exists(x => x.Title == command.Title && x.Id != command.Id) ||
                _branchRepository.Exists(x => x.Code == command.Code && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            branch.Edit(command.Title, command.HeadQ, command.Code, command.OldCode, command.AuthorizationCode, command.AuthorizationDate,
                command.TelPreCode, command.Telephone, command.Fax, command.PostalCode, command.Address, command.Keywords,
                command.MetaDescription, command.Slug);

            _branchRepository.SaveChanges();

            return operation;
        }

        public OperationResult Activate(long id)
        {
            var operation = new OperationResult();

            var branch = _branchRepository.Get(id);

            if (branch == null)
                return operation.Failed(ApplicationMessages.NotFound);

            branch.Activate();
            _branchRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Deactivate(long id)
        {
            var operation = new OperationResult();

            var branch = _branchRepository.Get(id);

            if (branch == null)
                return operation.Failed(ApplicationMessages.NotFound);

            branch.DeActive();
            _branchRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditBranch GetDetails(long id)
        {
            return _branchRepository.GetDetails(id);
        }

        public List<BranchViewModel> Search(BranchSearchModel searchModel)
        {
            return _branchRepository.Search(searchModel);
        }
    }
}
