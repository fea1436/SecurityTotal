namespace _02_SecTotalQuery.Contract.Branch
{
    public class BranchQueryModel
    {
        public string Title { get; set; }
        public int HeadQ { get; set; }
        public int Code { get; set; }
        public int OldCode { get; set; }
        public string AuthorizationCode { get; set; }
        public string AuthorizationDate { get; set; }
        public string TelPreCode { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public long PostalCode { get; set; }
        public bool ActivationStatus { get; set; }
        public string Address { get; set; }
        public bool OwnershipStatus { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
    }
}
