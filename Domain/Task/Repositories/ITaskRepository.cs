namespace Domain.Task.Repositories
{
    public interface ITaskRepository
    {
        TaskEntity? Get(string id);
    }
}
