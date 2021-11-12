using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonnelManagement.ApplicationContract.HireType;

namespace ServiceHost.Areas.Portal.Pages.Personnel.HireType
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public HireTypeSearchModel SearchModel;
        public List<HireTypeViewModel> HireTypes;

        private readonly IHireTypeApplication _hireTypeApplication;

        public IndexModel(IHireTypeApplication hireTypeApplication)
        {
            _hireTypeApplication = hireTypeApplication;
        }

        public void OnGet(HireTypeSearchModel searchModel)
        {
            HireTypes = _hireTypeApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateHireType());
        }

        public JsonResult OnPostCreate(CreateHireType command)
        {
            var result = _hireTypeApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var hireType = _hireTypeApplication.GetDetails(id);
            return Partial("Edit", hireType);
        }

        public JsonResult OnPostEdit(EditHireType command)
        {
            var result = _hireTypeApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetActivate(long id)
        {
            var result = _hireTypeApplication.Activate(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDeActivate(long id)
        {
            var result = _hireTypeApplication.Deactivate(id);
            return RedirectToPage("./Index");
        }
    }
}