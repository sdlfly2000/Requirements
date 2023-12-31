﻿using Application.Models;
using Application.UnitOfWorks;
using Domain.Task.Repositories;
using MediatR;

namespace Application.Commands
{
    internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponse>
    {
        private readonly IRequirementUnitOfWork _uow;
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(
            IRequirementUnitOfWork uow, 
            ITaskRepository taskRepository)
        {
            _uow = uow;
            _taskRepository = taskRepository;
        }

        public Task<CreateTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            _taskRepository.Add(request.Task);
            _uow.SaveAllChanges();
            return Task.FromResult(new CreateTaskResponse { TaskId = request.Task.ID.Code }); ;
        }
    }
}
