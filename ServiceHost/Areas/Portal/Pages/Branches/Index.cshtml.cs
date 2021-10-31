using System.Collections.Generic;
using _01_Framework.Infrastructure;
using BranchManagement.Application.Contract.Branch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Portal.Pages.Branches
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
            BHeadQs = new SelectList(_branchApplication.GetAllHeadQ(), "Code", "Title");
            Branches = _branchApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateBranch());
        }

        public JsonResult OnPostCreate(CreateBranch command)
        {
            var result = _branchApplication.Add(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var articleCategory = _branchApplication.GetDetails(id);
            return Partial("Edit", articleCategory);
        }

        public JsonResult OnPostEdit(EditBranch command)
        {
            var result = _branchApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}