namespace BranchManagement.Application.Contract.Branch
{
    public class EditBranch : CreateBranch
    {
        public long Id { get; set; }
        public bool ActivationStatus { get; set; }
    }
}