using Domain.UserStory;

namespace Domain.Task
{
    public class TaskEntity : BaseRecord
    {
        private string _id { get; }

        public TaskReference ID { get => new TaskReference(_id); }

        public string? UserStoryId { get; set; }

        public TaskEntity()
        {
            _id = Guid.NewGuid().ToString();
        }

        public static TaskEntity Create(
            string title,
            string? description,
            Guid? ownerId,
            TimeSpan? period,
            Guid? createdById)
        {
            return new TaskEntity
            {
                Title = title,
                Description = description ?? string.Empty,
                OwnerId = ownerId,
                StartedOn = DateTime.UtcNow,
                Period = period,
                Status = RecordStatus.Initial,
                ModifiedOn = DateTime.UtcNow,
                ModifiedById = ownerId,
                CreatedOn = DateTime.UtcNow,
                CreatedById = createdById
            };
        }
    }
}
