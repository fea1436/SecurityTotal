namespace CoreManagement.Application.Contract.HireType
{
    public class EditHireType : CreateHireType
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
    }
}