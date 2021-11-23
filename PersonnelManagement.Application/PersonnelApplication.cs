using System.Collections.Generic;
using _01_Framework.Application;
using PersonnelManagement.ApplicationContract.Personnel;
using PersonnelManagement.Domain.PersonnelAgg;

namespace PersonnelManagement.Application
{
    public class PersonnelApplication : IPersonnelApplication
    {
        private readonly IPersonnelRepository _personnelRepository;

        public PersonnelApplication(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public OperationResult Add(CreatePersonnel command)
        {
            OperationResult operation = new OperationResult();
            if ((_personnelRepository.Exists(x => x.PersonnelId == command.PersonnelId)) ||
                (_personnelRepository.Exists(x => x.Ssid == command.Ssid)))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            var newPersonnel = new Personnel(command.PersonnelId, command.Name, command.Family, command.Ssid,
                command.BirthDate, command.BirthPlace,
                command.Picture, command.PictureAlt, command.PictureTitle, command.HireDate, command.Branch, command.HireTypeId);

            _personnelRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Edit(EditPersonnel command)
        {
            OperationResult operation = new OperationResult();

            var personnel = _personnelRepository.Get(command.Id);

            if (personnel == null)
                return operation.Failed(ApplicationMessages.NotFound);

            if ((_personnelRepository.Exists(x=>(x.Ssid == command.Ssid && x.Id !=  command.Id))) ||
                (_personnelRepository.Exists(x => (x.PersonnelId == command.PersonnelId && x.Id != command.Id))) ||
                (_personnelRepository.Exists(x => (x.Ssid == command.Ssid && x.PersonnelId == command.PersonnelId && x.Id != command.Id))))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            personnel.Edit(command.PersonnelId, command.Name, command.Family, command.Ssid, command.BirthDate, command.BirthPlace,
                command.Picture, command.PictureAlt, command.PictureTitle, command.HireDate, command.Branch, command.HireTypeId);
            _personnelRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditPersonnel GetDetails(long id)
        {
            return _personnelRepository.GetDetails(id);
        }

        public List<PersonnelViewModel> GetAllPersonnel()
        {
            return _personnelRepository.GetAllPersonnel();
        }

        public List<PersonnelViewModel> Search(PersonnelSearchModel searchModel)
        {
            return _personnelRepository.Search(searchModel);
        }
    }
}

