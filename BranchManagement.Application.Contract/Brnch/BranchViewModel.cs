namespace BranchManagement.Application.Contract.Brnch
{
    public class BranchViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long HeadQ { get; set; }
        public long Code { get; set; }
        public long OldCode { get; set; }
        public bool IsActive { get; set; }
        public string LastChange { get; set; }
    }
}