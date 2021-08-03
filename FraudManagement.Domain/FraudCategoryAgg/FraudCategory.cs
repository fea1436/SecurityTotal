using _00_Framework.Domain;

namespace FraudManagement.Domain.FraudCategoryAgg
{
    public class FraudCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public FraudCategory(string name, string description, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            IsActive = true;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string description, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void SetActive()
        {
            IsActive = true;
        }

        public void SetNotActive()
        {
            IsActive = false;
        }
    }
}
