using Domain.Task;

namespace Domain.UserStory
{
    public class UserStoryEntity : BaseRecord
    {
        private string _id { get; }

        public UserStoryReference ID { get => new UserStoryReference(_id); }

        public string? UserRequirementId {  get; }

        public virtual List<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();
    }
}
