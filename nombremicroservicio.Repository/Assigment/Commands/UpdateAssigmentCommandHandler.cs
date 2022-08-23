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
    public class UpdateAssigmentCommandHandler : AsyncRequestHandler<UpdateAssigmentCommand>
    {
        readonly AssigmentService _assigmentService;

        public UpdateAssigmentCommandHandler(AssigmentService assigmentService)
        {
            _assigmentService = assigmentService;

        }

        protected override async Task Handle(UpdateAssigmentCommand request, CancellationToken cancellationToken)
        {
            await _assigmentService.UpdateAssigmentAsync(new Entities.Assigment
            {
                Id = request.Guid,
                Date = request.Date,

            });
        }
    }
}
