using MediatR;
using nombremicroservicio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Command
{
    public class UpdateClientCommandHandler : AsyncRequestHandler<UpdateClientCommand>
    {
        readonly ClientService _clientService;

        public UpdateClientCommandHandler(ClientService clientService)
        {
            _clientService = clientService;

        }

        protected override async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            await _clientService.UpdateClientAsync(new Entities.Client
            {
                Id = request.Guid,
            });
        }
    }
}
