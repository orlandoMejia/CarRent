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
    public class UpdateExecutiveCommandHandler : AsyncRequestHandler<UpdateExecutiveCommand>
    {
        readonly ExecutiveService _clientService;

        public UpdateExecutiveCommandHandler(ExecutiveService clientService)
        {
            _clientService = clientService;

        }

        protected override async Task Handle(UpdateExecutiveCommand request, CancellationToken cancellationToken)
        {
            await _clientService.UpdateExecutiveAsync(new Entities.Executive
            {
                Id = request.Guid,
            });
        }
    }
}
