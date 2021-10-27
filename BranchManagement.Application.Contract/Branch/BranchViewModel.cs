namespace BranchManagement.Application.Contract.Branch
{
    public class BranchViewModel
    {
        public string Title { get; set; }
        public string HeadQ { get; set; }
        public int Code { get; set; }
        public int OldCode { get; set; }
        public string AuthorizationCode { get; set; }
        public string AuthorizationDate { get; set; }
        public string FullTelNumber { get; set; }
        public string Address { get; set; }
        public bool ActivationStatus { get; set; }
    }
}