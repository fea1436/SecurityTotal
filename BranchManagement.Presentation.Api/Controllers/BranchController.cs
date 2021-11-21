using System.Collections.Generic;
using _02_SecTotalQuery.Contract.Branch;
using Microsoft.AspNetCore.Mvc;

namespace BranchManagement.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchQuery _branchQuery;

        public BranchController(IBranchQuery branchQuery)
        {
            _branchQuery = branchQuery;
        }

        [HttpGet]
        public List<BranchQueryModel> GetBranches()
        {
            return _branchQuery.GetBranches();
        }

        [HttpGet("{code}")]
        public BranchQueryModel GetBranchBy(int code)
        {
            return _branchQuery.GetBranchBy(code);
        }

        //[HttpGet("{slug}")]
        //public BranchQueryModel GetBranchBy(string slug)
        //{
        //    return _branchQuery.GetBranchBy(slug);
        //}

    }
}
