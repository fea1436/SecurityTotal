using System.Collections.Generic;
using _01_Framework.Application;
using PersonnelManagement.ApplicationContract.HireType;
using PersonnelManagement.Domain.HireTypeAgg;

namespace PersonnelManagement.Application
{
    public class HireTypeApplication : IHireTypeApplication
    {
        private readonly IHireTypeRepository _hireTypeRepository;

        public HireTypeApplication(IHireTypeRepository hireTypeRepository)
        {
            _hireTypeRepository = hireTypeRepository;
        }

        public OperationResult Create(CreateHireType command)
        {
            OperationResult operation = new OperationResult();
            if (_hireTypeRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            var hireType = new HireType(command.Title);
            _hireTypeRepository.Create(hireType);
            _hireTypeRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditHireType command)
        {
            OperationResult operation = new OperationResult();

            var hireType = _hireTypeRepository.Get(command.Id);

            if (hireType == null)
                return operation.Failed(ApplicationMessages.NotFound);

            if (_hireTypeRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            hireType.Edit(command.Title);
            _hireTypeRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Activate(long id)
        {
            OperationResult operation = new OperationResult();

            var hireType = _hireTypeRepository.Get(id);

            if (hireType == null)
                return operation.Failed(ApplicationMessages.NotFound);

            hireType.Activate();
            _hireTypeRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Deactivate(long id)
        {
            OperationResult operation = new OperationResult();

            var hireType = _hireTypeRepository.Get(id);

            if (hireType == null)
                return operation.Failed(ApplicationMessages.NotFound);

            hireType.DeActivate();
            _hireTypeRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditHireType GetDetails(long id)
        {
            return _hireTypeRepository.GetDetails(id);
        }

        public List<HireTypeViewModel> GetAll()
        {
            return _hireTypeRepository.GetAllHireTypes();
        }

        public List<HireTypeViewModel> Search(HireTypeSearchModel searchModel)
        {
            return _hireTypeRepository.Search(searchModel);
        }
    }
}
