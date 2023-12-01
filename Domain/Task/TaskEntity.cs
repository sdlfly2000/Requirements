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

        public static TaskEntity Create(string title, string description)
        {
            return new TaskEntity()
            {
                Title = title,
                Description = description,
                CreatedOn = DateTime.UtcNow,

            };
        }
    }
}
