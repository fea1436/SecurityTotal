﻿using System;

namespace BranchManagement.Application.Contract.Branch
{
    public class CreateBranch
    {
        public string Title { get; set; }
        public int HeadQ { get; set; }
        public int Code { get; set; }
        public int OldCode { get; set; }
        public string AuthorizationCode { get; set; }
        public DateTime AuthorizationDate { get; set; }
        public string TelPreCode { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public long PostalCode { get; set; }
        public string Address { get; set; }
    }
}
