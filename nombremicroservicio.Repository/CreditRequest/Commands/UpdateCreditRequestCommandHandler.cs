using MediatR;
using nombremicroservicio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.CreditRequest.Command
{
    public class UpdateCreditRequestCommandHandler : AsyncRequestHandler<UpdateCreditRequestCommand>
    {
        readonly CreditRequestService _creditRequestService;

        public UpdateCreditRequestCommandHandler(CreditRequestService creditRequestService)
        {
            _creditRequestService = creditRequestService;

        }

        protected override async Task Handle(UpdateCreditRequestCommand request, CancellationToken cancellationToken)
        {
            await _creditRequestService.UpdateCreditRequestAsync(new Entities.CreditRequest
            {
                Id = request.Guid,
            });
        }
    }
}
