using System;

namespace PersonnelManagement.ApplicationContract.Personnel
{
    public class PersonnelViewModel
    {
        public long PersonnelId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Ssid { get; set; }
        public string Branch{ get; set; }
        public DateTime BirthDate { get; set; }
        public long HireTypeId { get; set; }
        public string HireTypeTitle { get; set; }
        public DateTime HireDate { get; set; }
    }
}