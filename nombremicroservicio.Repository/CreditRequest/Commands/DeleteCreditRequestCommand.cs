using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.CreditRequest.Command
{
    public record DeleteCreditRequestCommand(
        [Required] Guid Guid
    ) : IRequest;
}
