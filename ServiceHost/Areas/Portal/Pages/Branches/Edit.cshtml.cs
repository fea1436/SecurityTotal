using BranchManagement.Application.Contract.Branch;
using BranchManagement.Application.Contract.OwnershipStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Portal.Pages.Branches
{
    public class EditModel : PageModel
    {
        private readonly IBranchApplication _branchApplication;
        private readonly IOwnershipStatusApplication _ownershipStatusApplication;

        public SelectList Ownerships;
        public EditBranch Command;

        public EditModel(IBranchApplication branchApplication, IOwnershipStatusApplication ownershipStatusApplication)
        {
            _branchApplication = branchApplication;
            _ownershipStatusApplication = ownershipStatusApplication;
        }

        public void OnGet(long id)
        {
            Command = _branchApplication.GetDetails(id);
            Ownerships = new SelectList(_ownershipStatusApplication.GetAllOwnershipStatus(), "Status", "Title");
        }

        public IActionResult OnPost(EditBranch command)
        {
            var result = _branchApplication.Edit(command);
            return Redirect("./Index");
        }
    }
}
