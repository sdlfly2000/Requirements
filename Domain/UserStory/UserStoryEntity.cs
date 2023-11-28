using Domain.Task;
using System.Collections.ObjectModel;

namespace Domain.UserStory
{
    public class UserStoryEntity : BaseRecord
    {
        private string _id { get; }
        private List<TaskEntity> _tasks { get; } = new List<TaskEntity>();

        public UserStoryReference ID { get => new UserStoryReference(_id); }

        public ReadOnlyCollection<TaskEntity> Tasks => _tasks.AsReadOnly();
    }
}
