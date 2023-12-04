using Application.Commands;
using Application.Models;
using Common.Core.DependencyInjection;
using MediatR;

namespace Application
{
    [ServiceLocate(typeof(IApplicationService))]
    public class ApplicationService : IApplicationService
    {
        private readonly IMediator _mediator;

        public ApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CreateTaskResponse> Create(CreateTaskRequest request)
        {
            return await _mediator.Send(new CreateTaskCommand(request));
        }
    }
}
