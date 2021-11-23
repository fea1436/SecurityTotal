namespace CoreManagement.Domain.OwnershipStatusAgg
{
    public class OwnershipStatus
    {
        public bool Status { get; private set; }
        public string Title { get; private set; }

        public OwnershipStatus(bool status, string title)
        {
            Status = status;
            Title = title;
        }
    }
}
