using Requirement.Common;

namespace Domain.Task
{
    public class TaskReference : Reference
    {
        public TaskReference(string code) : base(code, CacheField.Task)
        {
        }
    }
}
