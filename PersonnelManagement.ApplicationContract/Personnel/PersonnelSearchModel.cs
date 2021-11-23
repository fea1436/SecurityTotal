using System;

namespace PersonnelManagement.ApplicationContract.Personnel
{
    public class PersonnelSearchModel
    {
        public long PersonnelId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Ssid { get; set; }
        public long HireTypeId { get; set; }
        public string HireDate { get; set; }
        public string Branch { get; set; }
    }
}