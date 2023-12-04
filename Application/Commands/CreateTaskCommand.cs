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
            Task = new TaskEntity
            {
                Title = request.Title,
                Description = request.Description,
                OwnerId = Guid.Parse(request.OwnerId),
                StartedOn = request.StartedOn,
                Period = request.Period,
                Status = RecordStatus.Initial,
                ModifiedOn = DateTime.UtcNow,
                ModifiedById = Guid.Parse(request.OwnerId),
                CreatedOn = DateTime.UtcNow,
                CreatedById = Guid.Parse(request.OwnerId)
            };
        }

        public TaskEntity Task { get; private set; }
    }
}
