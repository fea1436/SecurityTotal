using System;
using _01_Framework.Domain;

namespace BranchManagement.Domain.BranchAgg
{
    public class Branch : EntityBase
    {
        public string Title { get; private set; }
        public int HeadQ { get; private set; }
        public int Code { get; private set; }
        public int OldCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public DateTime AuthorizationDate { get; private set; }
        public string TelPreCode { get; private set; }
        public string Telephone { get; private set; }
        public string Fax { get; private set; }
        public long PostalCode { get; private set; }
        public bool ActivationStatus { get; private set; }
        public string Address { get; private set; }
        public bool OwnershipStatus { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public Branch(string title, int headQ, int code, int oldCode, string authorizationCode, DateTime authorizationDate, bool ownershipStatus,
            string telPreCode, string telephone, string fax, long postalCode, string address, string keywords, string metaDescription, string slug)
        {
            Title = title;
            HeadQ = headQ;
            Code = code;
            OldCode = oldCode;
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            TelPreCode = telPreCode;
            Telephone = telephone;
            Fax = fax;
            PostalCode = postalCode;
            ActivationStatus = true;
            Address = address;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            OwnershipStatus = ownershipStatus;
        }

        public void Edit(string title, int headQ, int code, int oldCode, string authorizationCode, DateTime authorizationDate, bool ownershipStatus,
            string telPreCode, string telephone, string fax, long postalCode, string address, string keywords, string metaDescription, string slug)
        {
            Title = title;
            HeadQ = headQ;
            Code = code;
            OldCode = oldCode;
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            TelPreCode = telPreCode;
            Telephone = telephone;
            Fax = fax;
            PostalCode = postalCode;
            Address = address;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            OwnershipStatus = ownershipStatus;
        }

        public void Activate()
        {
            ActivationStatus = true;
        }

        public void DeActive()
        {
            ActivationStatus = false;
        }
    }
}
