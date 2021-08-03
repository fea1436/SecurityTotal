using System;
using System.Collections.Generic;
using System.Transactions;
using _00_Framework.Domain;

namespace BranchManagement.Domain.BranchAgg
{
    public class Branch : EntityBase
    {
        public long BranchId { get; private set; }
        public long? ParentBranchId { get; private set; }
        public virtual Branch ParentBranch { get; private set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public string Name { get; private set; }
        public long OldCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public string AuthorizationDate { get; private set; }
        public string TelPreCode { get; private set; }
        public string TelNumber { get; private set; }
        public string FaxNumber { get; private set; }
        public bool IsActive { get; private set; }
        public string Address { get; private set; }
        public DateTime LastChange { get; private set; }
        public bool IsHeadQ { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }

        public Branch(long branchId, long? parentBranchId, string name, long oldCode, string authorizationCode,
            string authorizationDate, string telPreCode, string telNumber, string faxNumber, bool isActive, 
            string address, DateTime lastChange, bool isHeadQ, string slug, string keywords, string metaDescription)
        {
            BranchId = branchId;
            ParentBranchId = parentBranchId;
            Name = name;
            OldCode = oldCode;
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            TelPreCode = telPreCode;
            TelNumber = telNumber;
            FaxNumber = faxNumber;
            IsActive = true;
            Address = address;
            LastChange = DateTime.Now;
            IsHeadQ = isHeadQ;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void Edit(long branchId, long? parentBranchId, string name, long oldCode, string authorizationCode,
            string authorizationDate, string telPreCode, string telNumber, string faxNumber, bool isActive,
            string address, DateTime lastChange, bool isHeadQ, string slug, string keywords, string metaDescription)
        {
            BranchId = branchId;
            ParentBranchId = parentBranchId;
            Name = name;
            OldCode = oldCode;
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            TelPreCode = telPreCode;
            TelNumber = telNumber;
            FaxNumber = faxNumber;
            IsActive = true;
            Address = address;
            LastChange = DateTime.Now;
            IsHeadQ = isHeadQ;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void SetActive()
        {
            IsActive = true;
        }

        public void SetNotActive()
        {
            IsActive = false;
        }
    }
}
