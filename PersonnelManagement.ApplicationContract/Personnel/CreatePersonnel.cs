using System;

namespace PersonnelManagement.ApplicationContract.Personnel
{
    public class CreatePersonnel
    {
        public long PersonnelId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Ssid { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long HireTypeId { get; set; }
        public DateTime HireDate { get; set; }
    }
}
