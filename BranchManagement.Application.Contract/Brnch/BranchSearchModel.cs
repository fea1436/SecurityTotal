namespace BranchManagement.Application.Contract.Brnch
{
    public class BranchSearchModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long HeadQ { get; set; }
        public long Code { get; set; }
        public long OldCode { get; set; }
    }
}