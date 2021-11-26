using System.Collections.Generic;
using CoreManagement.Application.Contract.Branch;
using CoreManagement.Application.Contract.HireType;
using CoreManagement.Application.Contract.Personnel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Portal.Pages.Personnel.Personnel
{
    public class IndexModel : PageModel
    {
        public PersonnelSearchModel SearchModel;
        public List<PersonnelViewModel> Personnel;
        public SelectList HireTypes;

        private readonly IBranchApplication _branchApplication;
        private readonly IPersonnelApplication _personnelApplication;
        private readonly IHireTypeApplication _hireTypeApplication;

        public IndexModel(IPersonnelApplication personnelApplication, IHireTypeApplication hireTypeApplication, IBranchApplication branchApplication)
        {
            _personnelApplication = personnelApplication;
            _hireTypeApplication = hireTypeApplication;
            _branchApplication = branchApplication;
        }

        public void OnGet(PersonnelSearchModel searchModel)
        {
            Personnel = _personnelApplication.Search(searchModel);

            HireTypes = new SelectList(_hireTypeApplication.GetAll(), "Id", "Title");
        }

        public IActionResult OnGetCreate()
        {
            var personnel = new CreatePersonnel
            {
                AllBranchList = _branchApplication.GetAllBranches(),
                AllHireTypeList = _hireTypeApplication.GetAll()
            };

            return Partial("./Create", personnel);
        }

        public JsonResult OnPostCreate(CreatePersonnel command)
        {
            var result = _personnelApplication.Add(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var personnel = _personnelApplication.GetDetails(id);
            return Partial("Edit", personnel);
        }

        public JsonResult OnPostEdit(EditPersonnel command)
        {
            var result = _personnelApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}