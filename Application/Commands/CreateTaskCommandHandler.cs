using Application.Models;
using Infra.Database.MySQL.UnitOfWork;
using MediatR;

namespace Application.Commands
{
    internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateTaskCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskId = _uow.TaskRepository.Add(request.Task);
            _uow.Commit();
            return Task.FromResult(new CreateTaskResponse { TaskId = taskId });
        }
    }
}
