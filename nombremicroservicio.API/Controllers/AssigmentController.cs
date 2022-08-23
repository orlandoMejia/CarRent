using MediatR;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Assigment.Command;
using nombremicroservicio.Repository.Assigment.Queries;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [ApiController]
    [Route("asignacion")]
    public class AssigmentController
    {
        readonly IMediator _mediator = default!;

        public AssigmentController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<AssigmentDto> Get(Guid id) => await _mediator.Send(new AssigmentQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(CreateAssigmentCommand assigment) => await _mediator.Send(assigment);

        [HttpPut]
        public async Task<GuidResultDto> Put(UpdateAssigmentCommand assigment)
        {

            var assigmentUpdateRequest = new UpdateAssigmentCommand(
                assigment.Guid, assigment.Date, assigment.IdClient, assigment.IdDriveWay
            );

            await _mediator.Send(assigmentUpdateRequest);

            return new GuidResultDto { id = assigment.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new DeleteAssigmentCommand(id));
    }
}
