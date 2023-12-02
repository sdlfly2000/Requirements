using Domain.Task;

namespace Domain.UserStory
{
    public class UserStoryEntity : BaseRecord
    {
        private string _id { get; }

        public UserStoryReference ID { get => new UserStoryReference(_id); }

        public string? UserRequirementId {  get; }

        public virtual List<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();

        public UserStoryEntity()
        {
            _id = Guid.NewGuid().ToString();
        }

        public void AddTask(TaskEntity task)
        {
            Tasks.Add(task);
        }
    
        public static UserStoryEntity Create(
            string title,
            string? description,
            Guid? ownerId,
            TimeSpan? period,
            Guid? createdById)
        {
            return new UserStoryEntity
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
