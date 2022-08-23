using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.CreditRequest.Queries
{
    public record CreditRequestQuery([Required] Guid Id) : IRequest<CreditRequestDto>;
}
