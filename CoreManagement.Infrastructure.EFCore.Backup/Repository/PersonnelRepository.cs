using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using CoreManagement.Application.Contract.Personnel;
using CoreManagement.Domain.PersonnelAgg;

namespace CoreManagement.Infrastructure.EFCore.Repository
{
    public class PersonnelRepository : RepositoryBase<long, Personnel>, IPersonnelRepository
    {
        private readonly CoreContext _coreContext;

        public PersonnelRepository(CoreContext context) : base(context)
        {
            _coreContext = context;
        }

        public EditPersonnel GetDetails(long id)
        {
            return _coreContext.Personnel.Select(x => new EditPersonnel
            {
                PersonnelId = x.PersonnelId,
                Name = x.Name,
                Family = x.Family,
                Ssid = x.Ssid,
                BirthDate = x.BirthDate,
                BirthPlace = x.BirthPlace,
                HireDate = x.HireDate,
                HireTypeId = x.HireTypeId,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PersonnelViewModel> GetAllPersonnel()
        {
            var hireType = _coreContext.HireTypes.Select(x => new {x.Id, x.Title}).ToList();

            var personnel =  _coreContext.Personnel.Select(x => new PersonnelViewModel
            {
                PersonnelId = x.PersonnelId,
                Name = x.Name,
                Family = x.Family,
                BirthDate = x.BirthDate,
                Ssid = x.Ssid,
                HireDate = x.HireDate,
                HireTypeId = x.HireTypeId
            }).OrderBy(x => x.PersonnelId).ToList();

            foreach (var singlePersonnel in personnel)
            {
                singlePersonnel.HireTypeTitle = hireType.FirstOrDefault(x => x.Id == singlePersonnel.HireTypeId)?.Title;
            }

            return personnel;
        }

        public List<PersonnelViewModel> Search(PersonnelSearchModel searchModel)
        {
            var hireType = _coreContext.HireTypes.Select(x => new { x.Id, x.Title }).ToList();


            var query = _coreContext.Personnel.Select(x => new PersonnelViewModel
            {
                PersonnelId = x.PersonnelId,
                Name = x.Name,
                Family = x.Family,
                BirthDate = x.BirthDate,
                Ssid = x.Ssid,
                HireDate = x.HireDate,
                HireTypeId = x.HireTypeId
            });

            if (searchModel.PersonnelId > 0)
                query = query.Where(x => x.PersonnelId == searchModel.PersonnelId);

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Family))
                query = query.Where(x => x.Family.Contains(searchModel.Family));

            if (!string.IsNullOrWhiteSpace(searchModel.Ssid))
                query = query.Where(x => x.Ssid.Contains(searchModel.Ssid));

            if (searchModel.HireTypeId > 0)
                query = query.Where(x => x.HireTypeId == searchModel.HireTypeId);

            if (!string.IsNullOrWhiteSpace(searchModel.HireDate))
                query = query.Where(x => x.HireDate == searchModel.HireDate.ToGeorgianDateTime());


            var personnel = query.OrderBy(x => x.PersonnelId).ToList();

            foreach (var singlePersonnel in personnel)
            {
                singlePersonnel.HireTypeTitle = hireType.FirstOrDefault(x => x.Id == singlePersonnel.HireTypeId)?.Title;
            }

            //foreach (var singlePersonnel in personnel)
            //{
            //    singlePersonnel.Branch = 
            //}

            return personnel;
        }
    }
}
