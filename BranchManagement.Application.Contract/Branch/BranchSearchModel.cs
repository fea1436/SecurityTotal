﻿namespace BranchManagement.Application.Contract.Branch
{
    public class BranchSearchModel
    {
        public string Title { get; set; }
        public string HeadQ { get; set; }
        public int Code { get; set; }
        public int OldCode { get; set; }
        public bool ActivationStatus { get; set; }
    }
}