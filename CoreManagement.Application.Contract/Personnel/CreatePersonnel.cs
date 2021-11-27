using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using CoreManagement.Application.Contract.Branch;
using CoreManagement.Application.Contract.HireType;
using Microsoft.AspNetCore.Http;

namespace CoreManagement.Application.Contract.Personnel
{
    public class CreatePersonnel
    {
        [Range(1111, 99999, ErrorMessage = ValidationMessages.NotInRange)]
        public long PersonnelId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Family { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Ssid { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BirthPlace { get; set; }

        [FileExtensionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileExtension)]
        [MaxFileSiz(1 * 1024 * 1024, ErrorMessage = ValidationMessages.FileOverSize)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long HireTypeId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string HireDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long BranchId { get; set; }

        public List<HireTypeViewModel> AllHireTypeList { get; set; }
        public List<BranchViewModel> AllBranchList { get; set; }
    }
}
