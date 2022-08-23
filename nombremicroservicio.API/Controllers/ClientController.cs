using MediatR;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Client.Command;
using nombremicroservicio.Repository.Client.Queries;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClientController
    {
        readonly IMediator _mediator = default!;

        public ClientController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<ClientDto> Get(Guid id) => await _mediator.Send(new ClientQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(CreateClientCommand client) => await _mediator.Send(client);

        [HttpPut]
        public async Task<GuidResultDto> Put(UpdateClientCommand client)
        {

            var clientUpdateRequest = new UpdateClientCommand(
                client.Guid, client.IdentificationNumber, client.Names, client.Age, client.BirthDate,
                client.LastNames, client.Address, client.Phone, client.MaterialStatus, client.SpoceIdentification,
                client.SpoceName, client.CreditSubject
            );

            await _mediator.Send(clientUpdateRequest);

            return new GuidResultDto { id = client.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new DeleteClientCommand(id));
    }
}
