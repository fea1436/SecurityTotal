using System.Collections.Generic;
using _00_Framework.Application;
using FraudManagement.Application.Contract.FrdCategory;
using FraudManagement.Domain.FraudCategoryAgg;

namespace FraudManagement.Application
{
    public class FraudCategoryApplication : IFraudCategoryApplication
    {
        private readonly IFraudCategoryRepository _fraudCategoryRepository;

        public FraudCategoryApplication(IFraudCategoryRepository fraudCategoryRepository)
        {
            _fraudCategoryRepository = fraudCategoryRepository;
        }

        public OperationResult Create(CreateFraudCategory command)
        {
            var operation = new OperationResult();

            if (_fraudCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.Duplicated);

            string slug = command.Slug.Slugify();

            var fraudCategory = new FraudCategory(command.Name, command.Description, command.Keywords,
                command.MetaDescription, slug);
            
            _fraudCategoryRepository.Create(fraudCategory);
            _fraudCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditFraudCategory command)
        {
            var operation = new OperationResult();

            var fraudCategory = _fraudCategoryRepository.Get(command.Id);
            if (fraudCategory == null)
                return operation.Failed(ApplicationMessages.NotFound);

            if (_fraudCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.WouldBeDuplicated);

            string slug = command.Slug.Slugify();
            fraudCategory.Edit(command.Name, command.Description, command.Keywords, command.MetaDescription, slug);

            _fraudCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditFraudCategory GetDetails(long id)
        {
            return _fraudCategoryRepository.GetDeatails(id);
        }

        public List<FraudCategoryViewModel> Search(FraudCategorySearchModel command)
        {
            return _fraudCategoryRepository.Search(command);
        }
    }
}
