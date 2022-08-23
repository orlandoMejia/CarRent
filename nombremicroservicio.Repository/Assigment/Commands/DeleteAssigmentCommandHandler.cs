using MediatR;
using nombremicroservicio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Command
{

    public class DeleteAssigmentCommandHandler : AsyncRequestHandler<DeleteAssigmentCommand>
    {
        readonly AssigmentService _assigmentService;

        public DeleteAssigmentCommandHandler(AssigmentService assigmentService)
        {
            _assigmentService = assigmentService;

        }

        protected override async Task Handle(DeleteAssigmentCommand request, CancellationToken cancellationToken)
        {
            await _assigmentService.DeleteAssigmentAsync(request.Guid);
        }
    }
}
