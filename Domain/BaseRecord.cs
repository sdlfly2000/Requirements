
namespace Domain
{
    public abstract class BaseRecord
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public Guid? OwnerId { get; set; }

        public DateTime? StartedOn { get; set; }

        public TimeSpan? Period { get; set; }

        public string? Status { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedById { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedById { get; set; }
    }
}
