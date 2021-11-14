using System.Collections.Generic;
using BranchManagement.Application.Contract.Branch;
using BranchManagement.Application.Contract.OwnershipStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Portal.Pages.Branches
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public BranchSearchModel SearchModel;
        public List<BranchViewModel> Branches;
        public SelectList BHeadQs;
        public SelectList AllOwnershipStatusList;

        private readonly IBranchApplication _branchApplication;
        private readonly IOwnershipStatusApplication _ownershipStatusApplication;

        public IndexModel(IBranchApplication branchApplication, IOwnershipStatusApplication ownershipStatusApplication)
        {
            _branchApplication = branchApplication;
            _ownershipStatusApplication = ownershipStatusApplication;
        }

        public void OnGet(BranchSearchModel searchModel)
        {
            AllOwnershipStatusList =
                new SelectList(_ownershipStatusApplication.GetAllOwnershipStatus(), "Status", "Title");

            BHeadQs = new SelectList(_branchApplication.GetAllHeadQ(), "Code", "Title");
            Branches = _branchApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var branch = new CreateBranch
            {
                AllOwnershipStatusList = _ownershipStatusApplication.GetAllOwnershipStatus()
            };

            return Partial("./Create", branch);
        }

        public JsonResult OnPostCreate(CreateBranch command)
        {
            var result = _branchApplication.Add(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var branch = _branchApplication.GetDetails(id);
            return Partial("Edit", branch);
        }

        public JsonResult OnPostEdit(EditBranch command)
        {
            var result = _branchApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetActivate(long id)
        {
            var result = _branchApplication.Activate(id);
            Message = result.Message;

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDeactivate(long id)
        {
            var result = _branchApplication.Deactivate(id);
            Message = result.Message;

            return RedirectToPage("./Index");
        }
    }
}