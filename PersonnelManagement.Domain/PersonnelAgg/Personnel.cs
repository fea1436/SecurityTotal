using System;
using _01_Framework.Domain;
using PersonnelManagement.Domain.HireTypeAgg;

namespace PersonnelManagement.Domain.PersonnelAgg
{
    public class Personnel : EntityBase
    {
        public long PersonnelId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Ssid { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string BirthPlace { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime HireDate { get; private set; }
        public long HireTypeId { get; private set; }
        public HireType HireType { get; private set; }

        public Personnel(long personnelId, string name, string family, string ssid, DateTime birthDate, string birthPlace,
            string picture, string pictureAlt, string pictureTitle, DateTime hireDate, long hireTypeId)
        {
            PersonnelId = personnelId;
            Name = name;
            Family = family;
            Ssid = ssid;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            HireDate = hireDate;
            HireTypeId = hireTypeId;
        }

        public void Edit(long personnelId, string name, string family, string ssid, DateTime birthDate, string birthPlace,
            string picture, string pictureAlt, string pictureTitle, DateTime hireDate, long hireTypeId)
        {
            PersonnelId = personnelId;
            Name = name;
            Family = family;
            Ssid = ssid;
            BirthDate = birthDate;
            BirthPlace = birthPlace;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            HireDate = hireDate;
            HireTypeId = hireTypeId;
        }
    }
}
