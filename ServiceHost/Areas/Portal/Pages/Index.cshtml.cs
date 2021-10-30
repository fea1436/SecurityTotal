using System.Collections.Generic;
using BranchManagement.Application.Contract.Branch;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Portal.Pages
{
    public class IndexModel : PageModel
    {
        public BranchSearchModel SearchModel;
        public List<BranchViewModel> Branches;
        public SelectList BHeadQs;

        private readonly IBranchApplication _branchApplication;

        public IndexModel(IBranchApplication branchApplication)
        {
            _branchApplication = branchApplication;
        }

        public void OnGet(BranchSearchModel searchModel)
        {
            BHeadQs = new SelectList(_branchApplication.get _productApplication.GetProducts(), "Id", "Name");
        }
    }
}
