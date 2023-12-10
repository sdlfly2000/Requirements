using Application.Models;
using Application.UnitOfWorks;
using Domain.Task.Repositories;
using MediatR;

namespace Application.Commands
{
    internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(
            IUnitOfWork uow, 
            ITaskRepository taskRepository)
        {
            _uow = uow;
            _taskRepository = taskRepository;
        }

        public Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskId = _taskRepository.Add(request.Task);
            _uow.SaveAllChanges();
            return Task.FromResult(new CreateTaskResponse { TaskId = taskId });
        }
    }
}
