using System.Collections.Generic;
using _01_Framework.Application;
using CoreManagement.Application.Contract.Personnel;
using CoreManagement.Domain.PersonnelAgg;

namespace CoreManagement.Application
{
    public class PersonnelApplication : IPersonnelApplication
    {
        private readonly IPersonnelRepository _coreRepository;

        public PersonnelApplication(IPersonnelRepository coreRepository)
        {
            _coreRepository = coreRepository;
        }

        public OperationResult Add(CreatePersonnel command)
        {
            OperationResult operation = new OperationResult();
            if ((_coreRepository.Exists(x => x.PersonnelId == command.PersonnelId)) ||
                (_coreRepository.Exists(x => x.Ssid == command.Ssid)))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            var newPersonnel = new Personnel(command.PersonnelId, command.Name, command.Family, command.Ssid,
                command.BirthDate, command.BirthPlace,
                command.Picture, command.PictureAlt, command.PictureTitle, command.HireDate, command.Branch, command.HireTypeId);

            _coreRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditPersonnel command)
        {
            OperationResult operation = new OperationResult();

            var personnel = _coreRepository.Get(command.Id);

            if (personnel == null)
                return operation.Failed(ApplicationMessages.NotFound);

            if ((_coreRepository.Exists(x=>(x.Ssid == command.Ssid && x.Id !=  command.Id))) ||
                (_coreRepository.Exists(x => (x.PersonnelId == command.PersonnelId && x.Id != command.Id))) ||
                (_coreRepository.Exists(x => (x.Ssid == command.Ssid && x.PersonnelId == command.PersonnelId && x.Id != command.Id))))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            personnel.Edit(command.PersonnelId, command.Name, command.Family, command.Ssid, command.BirthDate, command.BirthPlace,
                command.Picture, command.PictureAlt, command.PictureTitle, command.HireDate, command.Branch, command.HireTypeId);
            _coreRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditPersonnel GetDetails(long id)
        {
            return _coreRepository.GetDetails(id);
        }

        public List<PersonnelViewModel> GetAllPersonnel()
        {
            return _coreRepository.GetAllPersonnel();
        }

        public List<PersonnelViewModel> Search(PersonnelSearchModel searchModel)
        {
            return _coreRepository.Search(searchModel);
        }
    }
}

