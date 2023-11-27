namespace Domain.Task
{
    public class TaskEntity : BaseRecord
    {
        private string _id { get; }

        public TaskReference ID { get => new TaskReference(_id); }
    }
}
