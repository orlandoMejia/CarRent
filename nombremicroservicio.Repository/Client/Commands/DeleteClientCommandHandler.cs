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

    public class DeleteClientCommandHandler : AsyncRequestHandler<DeleteClientCommand>
    {
        readonly ClientService _clientService;

        public DeleteClientCommandHandler(ClientService clientService)
        {
            _clientService = clientService;

        }

        protected override async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _clientService.DeleteClientAsync(request.Guid);
        }
    }
}
