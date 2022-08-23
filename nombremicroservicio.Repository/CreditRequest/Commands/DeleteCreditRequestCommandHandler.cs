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

    public class DeleteCreditRequestCommandHandler : AsyncRequestHandler<DeleteCreditRequestCommand>
    {
        readonly CreditRequestService _creditRequestService;

        public DeleteCreditRequestCommandHandler(CreditRequestService creditRequestService)
        {
            _creditRequestService = creditRequestService;

        }

        protected override async Task Handle(DeleteCreditRequestCommand request, CancellationToken cancellationToken)
        {
            await _creditRequestService.DeleteCreditRequestAsync(request.Guid);
        }
    }
}
