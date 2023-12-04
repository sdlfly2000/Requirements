using Application.Models;

namespace Application
{
    public interface IApplicationService
    {
        Task<CreateTaskResponse> Create(CreateTaskRequest request);
    }
}
