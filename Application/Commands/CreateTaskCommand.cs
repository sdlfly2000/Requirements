using Application.Models;
using Domain;
using Domain.Task;
using MediatR;

namespace Application.Commands
{
    internal class CreateTaskCommand : IRequest<CreateTaskResponse>
    {
        public CreateTaskCommand(CreateTaskRequest request)
        {
            Task = TaskEntity.Create(
                request.Title,
                request.Description,
                Guid.Parse(request.OwnerId),
                request.Period,
                Guid.Parse(request.OwnerId));
        }

        public TaskEntity Task { get; private set; }
    }
}
