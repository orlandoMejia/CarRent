using MediatR;
using nombremicroservicio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Executive.Command
{

    public class DeleteExecutiveCommandHandler : AsyncRequestHandler<DeleteExecutiveCommand>
    {
        readonly ExecutiveService _clientService;

        public DeleteExecutiveCommandHandler(ExecutiveService clientService)
        {
            _clientService = clientService;

        }

        protected override async Task Handle(DeleteExecutiveCommand request, CancellationToken cancellationToken)
        {
            await _clientService.DeleteExecutiveAsync(request.Guid);
        }
    }
}
