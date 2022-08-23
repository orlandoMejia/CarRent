using MediatR;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Executive.Command;
using nombremicroservicio.Repository.Executive.Queries;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [ApiController]
    [Route("vendedor")]
    public class ExecutiveController
    {
        readonly IMediator _mediator = default!;

        public ExecutiveController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<ExecutiveDto> Get(Guid id) => await _mediator.Send(new ExecutiveQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(CreateExecutiveCommand executive) => await _mediator.Send(executive);

        [HttpPut]
        public async Task<GuidResultDto> Put(UpdateExecutiveCommand executive)
        {

            var executiveUpdateRequest = new UpdateExecutiveCommand(
                executive.Guid, executive.IdentificationNumber, executive.Names, executive.LastNames, executive.Address,
                executive.Phone, executive.Celphone, executive.DriveWay
            );

            await _mediator.Send(executiveUpdateRequest);

            return new GuidResultDto { id = executive.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new DeleteExecutiveCommand(id));
    }
}
