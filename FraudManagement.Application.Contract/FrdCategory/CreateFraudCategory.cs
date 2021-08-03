using System.ComponentModel.DataAnnotations;
using _00_Framework.Application;

namespace FraudManagement.Application.Contract.FrdCategory
{
    public class CreateFraudCategory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
    }
}
