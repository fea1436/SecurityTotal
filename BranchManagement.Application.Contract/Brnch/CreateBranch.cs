using System;
using System.ComponentModel.DataAnnotations;
using _00_Framework.Application;

namespace BranchManagement.Application.Contract.Brnch
{
    public class CreateBranch
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long HeadQ { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long Code { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long OldCode { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string AuthorizationCode { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string AuthorizationDate { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string TelPreCode { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string TelNumber { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string FaxNumber { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Address { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public DateTime LastChange { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public bool IsHeadQ { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)] 
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }
    }
}
