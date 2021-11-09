using _01_Framework.Domain;

namespace PersonnelManagement.Domain.HireTypeAgg
{
    public class HireType : EntityBase
    {
        public string Title { get; private set; }
        public bool IsActive { get; private set; }

        public HireType(string title)
        {
            Title = title;
            IsActive = true;
        }

        public void Edit(string title)
        {
            Title = title;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActivate()
        {
            IsActive = false;
        }
    }
}
