using BranchManagement.Application.Contract.Branch;
using BranchManagement.Application.Contract.OwnershipStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Portal.Pages.Branches
{
    public class CreateModel : PageModel
    {
        private readonly IBranchApplication _branchApplication;
        private readonly IOwnershipStatusApplication _ownershipStatusApplication;

        public SelectList Ownerships;
        public CreateBranch Command;

        public CreateModel(IOwnershipStatusApplication ownershipStatusApplication, IBranchApplication branchApplication)
        {
            _ownershipStatusApplication = ownershipStatusApplication;
            _branchApplication = branchApplication;
        }

        public void OnGet()
        {
            Ownerships = new SelectList(_ownershipStatusApplication.GetAllOwnershipStatus(), "Status", "Title");
        }

        public IActionResult OnPost(CreateBranch command)
        {
            var result = _branchApplication.Add(command);
            return Redirect("./Index");
        }
    }
}
