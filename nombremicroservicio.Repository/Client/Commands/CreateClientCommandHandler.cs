using MediatR;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Command
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, GuidResultDto>
    {
        readonly ClientService _clientService;

        public CreateClientCommandHandler(ClientService clientService)
        {
            _clientService = clientService;

        }


        async Task<GuidResultDto> IRequestHandler<CreateClientCommand, GuidResultDto>.Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clientService.RegisterClientAsync(new Entities.Client
            {
                Names = request.Names,
                Address = request.Address,
                Age = request.Age,
                Phone = request.Phone,
                BirthDate = request.BirthDate,
                CreditSubject = request.CreditSubject,
                IdentificationNumber = request.IdentificationNumber,
                LastNames = request.LastNames,
                MaterialStatus = request.MaterialStatus,
                SpoceIdentification = request.SpoceIdentification,
                SpoceName = request.SpoceName,
            });
            return new GuidResultDto { id = cliente.Id };
        }

    }
}
