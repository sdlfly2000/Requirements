namespace Application.Models
{
    public class CreateTaskRequest
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string OwnerId { get; set; }

        public DateTime? StartedOn { get; set; }

        public TimeSpan? Period { get; set; }

        public string? ModifiedById { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedById { get; set; }
    }
}
