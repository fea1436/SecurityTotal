using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using BranchManagement.Application.Contract.OwnershipStatus;

namespace BranchManagement.Application.Contract.Branch
{
    public class CreateBranch
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        [Range(1111, 9999, ErrorMessage = ValidationMessages.NotInRange)]
        public int HeadQ { get; set; }

        [Range(1111, 9999, ErrorMessage = ValidationMessages.NotInRange)]
        public int Code { get; set; }

        [Range(11111, 99999, ErrorMessage = ValidationMessages.NotInRange)]
        public int OldCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string AuthorizationCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string AuthorizationDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string TelPreCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Fax { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long PostalCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Address { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public bool OwnershipStatus { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        public List<OwnershipStatusViewModel> AllOwnershipStatusList { get; set; }
    }
}
